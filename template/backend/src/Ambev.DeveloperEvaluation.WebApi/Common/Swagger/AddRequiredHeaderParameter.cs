using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ambev.DeveloperEvaluation.WebApi.Common.Swagger
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Request-ID",
                In = ParameterLocation.Header,
                Description = "Unique request identifier for tracking purposes",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Format = "uuid"
                }
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-Client-Version",
                In = ParameterLocation.Header,
                Description = "Client application version",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
} 