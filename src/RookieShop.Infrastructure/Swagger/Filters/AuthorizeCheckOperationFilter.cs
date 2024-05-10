using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using RookieShop.Domain.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RookieShop.Infrastructure.Swagger.Filters;

public sealed class AuthorizeCheckOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var hasAuthorize =
            context.MethodInfo.DeclaringType?.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ??
            context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

        if (!hasAuthorize) return;

        operation.Responses.TryAdd(
            StatusCodes.Status401Unauthorized.ToString(), new() { Description = "Unauthorized" }
        );
        operation.Responses.TryAdd(
            StatusCodes.Status403Forbidden.ToString(), new() { Description = "Forbidden" }
        );

        OpenApiSecurityScheme oAuthScheme = new()
        {
            Reference = new() { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
        };

        operation.Security =
        [
            new() { [oAuthScheme] = [AuthScope.Read, AuthScope.Write] }
        ];
    }
}