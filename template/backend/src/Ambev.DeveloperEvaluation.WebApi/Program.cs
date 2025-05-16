using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Common.HealthChecks;
using Ambev.DeveloperEvaluation.Common.Logging;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.IoC;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Polly;
using Polly.Retry;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ambev.DeveloperEvaluation.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Starting web application...");
            Log.Information("Starting web application");

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            Console.WriteLine("WebApplicationBuilder created");
            
            builder.AddDefaultLogging();
            Console.WriteLine("Default logging configured");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            Console.WriteLine("Controllers and API Explorer added");

            // Add health checks
            builder.Services.AddHealthChecks()
                .AddDbContextCheck<DefaultContext>("database", tags: new[] { "ready" });
            builder.Services.AddHealthChecks(builder.Configuration);
            Console.WriteLine("Health checks configured");

            builder.Services.AddSwaggerGen(options =>
            {
                Console.WriteLine("Configuring Swagger...");
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Ambev Developer Evaluation API",
                    Version = "v1",
                    Description = @"API for managing sales records, including sales and sale items.
                    
                    ## Business Rules
                    
                    ### Quantity-based Discounts:
                    - 4+ items: 10% discount
                    - 10-20 items: 20% discount
                    
                    ### Restrictions:
                    - Maximum limit: 20 items per product
                    - No discounts allowed for quantities below 4 items
                    
                    ## Authentication
                    All endpoints require JWT Bearer token authentication.
                    
                    ## Rate Limiting
                    API calls are limited to 100 requests per minute per IP address.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Ambev Development Team",
                        Email = "dev@ambev.com.br"
                    }
                });

                // Enable XML comments for better documentation
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                // Add JWT Authentication to Swagger
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
                });

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
            Console.WriteLine("Swagger configured");

            Console.WriteLine("Configuring database connection...");
            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
                )
            );
            Console.WriteLine("Database connection configured");

            builder.Services.AddJwtAuthentication(builder.Configuration);
            Console.WriteLine("JWT authentication configured");

            builder.Services.AddResiliencePipeline("database-retry", pipeline =>
            {
                pipeline.AddRetry(new RetryStrategyOptions
                {
                    MaxRetryAttempts = 5,
                    Delay = TimeSpan.FromSeconds(2),
                    BackoffType = DelayBackoffType.Exponential,
                    ShouldHandle = new PredicateBuilder().Handle<Exception>()
                });
            });
            Console.WriteLine("Resilience pipeline configured");

            builder.RegisterDependencies();
            Console.WriteLine("Dependencies registered");

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);
            Console.WriteLine("AutoMapper configured");

            builder.Services.AddMediatR(cfg =>
            {
                try
                {
                    Console.WriteLine("Registering MediatR services...");
                    cfg.RegisterServicesFromAssemblies(
                        typeof(ApplicationLayer).Assembly,
                        typeof(Program).Assembly
                    );
                    Console.WriteLine("MediatR services registered successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error registering MediatR services: {ex}");
                    throw;
                }
            });
            Console.WriteLine("MediatR configured");

            try
            {
                builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                Console.WriteLine("Validation behavior configured");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configuring validation behavior: {ex}");
                throw;
            }

            var app = builder.Build();
            Console.WriteLine("WebApplication built");

            // Ensure database is created and migrations are applied
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var context = services.GetRequiredService<DefaultContext>();

                try
                {
                    Console.WriteLine("Applying database migrations...");
                    logger.LogInformation("Applying database migrations...");
                    context.Database.Migrate();
                    logger.LogInformation("Database migrations applied successfully");
                    Console.WriteLine("Database migrations applied successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying migrations: {ex}");
                    logger.LogError(ex, "An error occurred while applying database migrations");
                    throw;
                }
            }

            try
            {
                app.UseMiddleware<ValidationExceptionMiddleware>();
                Console.WriteLine("Validation middleware configured");

                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                    Console.WriteLine("Swagger UI configured");
                }

                app.UseHttpsRedirection();
                Console.WriteLine("HTTPS redirection configured");

                app.UseAuthentication();
                app.UseAuthorization();
                Console.WriteLine("Authentication and authorization configured");

                // Use health checks
                app.UseHealthChecks("/health", new HealthCheckOptions
                {
                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "application/json";
                        var response = new
                        {
                            status = report.Status.ToString(),
                            checks = report.Entries.Select(x => new
                            {
                                name = x.Key,
                                status = x.Value.Status.ToString(),
                                description = x.Value.Description,
                                duration = x.Value.Duration.ToString()
                            })
                        };
                        await context.Response.WriteAsJsonAsync(response);
                    }
                });
                Console.WriteLine("Health checks endpoints configured");

                app.UseHealthChecks("/health/ready", new HealthCheckOptions
                {
                    Predicate = (check) => check.Tags.Contains("ready")
                });

                app.MapControllers();
                Console.WriteLine("Controllers mapped");

                Console.WriteLine("Starting the application...");
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during application startup: {ex}");
                Log.Error(ex, "Error during application startup");
                throw;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex}");
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
