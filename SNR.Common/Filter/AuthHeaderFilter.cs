using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SNR.Common.Filter;

public class AuthHeaderFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
        {
            operation.Parameters = new List<OpenApiParameter>();
        }
        if (context.MethodInfo.Name == "Token")
        {
            return;
        }
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Token",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "String",
            }
        });
    }
}