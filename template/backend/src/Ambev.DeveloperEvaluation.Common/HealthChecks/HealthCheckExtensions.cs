using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Ambev.DeveloperEvaluation.Common.HealthChecks;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddCheck<ExternalEndpointHealthCheck>("external_endpoints", tags: new[] { "ready" });

        return services;
    }
}

public class ExternalEndpointHealthCheck : Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck
{
    public Task<Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> CheckHealthAsync(
        Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        // Add checks for external services here
        return Task.FromResult(Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Healthy("External endpoints are healthy"));
    }
} 