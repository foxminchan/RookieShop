using Ardalis.GuardClauses;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RookieShop.Infrastructure.Swagger.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RookieShop.Infrastructure.Swagger;

public static class Extension
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services)
        => services
            .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
            .AddFluentValidationRulesToSwagger()
            .AddSwaggerGen(c =>
            {
                c.SchemaFilter<StronglyTypedIdFilter>();
                c.SchemaFilter<SmartEnumSchemaFilter>();
            });

    public static IApplicationBuilder UseOpenApi(this WebApplication app, IConfiguration configuration)
    {
        const string appName = "Rookie Shop API";

        app.UseSwagger(c => c.PreSerializeFilters.Add((swagger, httpReq) =>
        {
            Guard.Against.Null(httpReq);

            swagger.Servers =
            [
                new()
                {
                    Url = $"{httpReq.Scheme}://{httpReq.Host.Value}",
                    Description = string.Join(
                        " ",
                        Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production,
                        nameof(Environment)
                    )
                }
            ];
        }));

        app.UseSwaggerUI(c =>
        {
            app.DescribeApiVersions()
                .Select(desc => new
                {
                    url = $"/swagger/{desc.GroupName}/swagger.json",
                    name = desc.GroupName.ToUpperInvariant()
                })
                .ToList()
                .ForEach(endpoint => c.SwaggerEndpoint(endpoint.url, endpoint.name));

            c.DocumentTitle = appName;
            c.OAuthClientId(configuration["OAuth:ClientId"]);
            c.OAuthClientSecret(configuration["OAuth:ClientSecret"]);
            c.OAuthAppName(appName);
            c.OAuthUsePkce();
            c.DisplayRequestDuration();
            c.EnableFilter();
            c.EnableValidator();
            c.EnableTryItOutByDefault();
            c.EnablePersistAuthorization();
        });

        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        return app;
    }
}