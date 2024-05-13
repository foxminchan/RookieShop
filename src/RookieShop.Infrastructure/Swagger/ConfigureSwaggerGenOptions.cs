using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Swagger.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RookieShop.Infrastructure.Swagger;

public sealed class ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider, IConfiguration config)
    : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName,
                new()
                {
                    Title = $"Rookie Shop API {description.ApiVersion}",
                    Description = "A project developed by a rookie transitioning to an engineer at NashTech",
                    Version = description.ApiVersion.ToString(),
                    Contact = new()
                    {
                        Name = "Nhan Nguyen",
                        Email = "nguyenxuannhan407@gmail.com",
                        Url = new("https://github.com/foxminchan")
                    },
                    License = new() { Name = "MIT", Url = new("https://opensource.org/licenses/MIT") }
                });
        }

        var urlExternal = config.GetValue<string>("OAuth:Authority");

        options.AddSecurityDefinition("oauth2",
            new()
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new()
                {
                    AuthorizationCode = new()
                    {
                        TokenUrl = new($"{urlExternal}/connect/token"),
                        AuthorizationUrl = new($"{urlExternal}/connect/authorize"),
                        Scopes = new Dictionary<string, string>
                        {
                            { AuthScope.Read, "Read Access to API" },
                            { AuthScope.Write, "Write Access to API" }
                        }
                    }
                }
            });

        options.OperationFilter<AuthorizeCheckOperationFilter>();
    }
}