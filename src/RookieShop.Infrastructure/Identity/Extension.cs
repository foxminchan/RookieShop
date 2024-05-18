using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Identity.Settings;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.Identity;

public static class Extension
{
    public static IHostApplicationBuilder AddIdentity(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOptionsWithValidateOnStart<OpenIdSettings>()
            .Bind(builder.Configuration.GetSection(nameof(OpenIdSettings)))
            .ValidateFluentValidation();

        var openIdSettings = builder.Configuration.GetSection(nameof(OpenIdSettings)).Get<OpenIdSettings>();

        Guard.Against.Null(openIdSettings);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Audience = nameof(RookieShop).ToLowerInvariant();
                options.Authority = openIdSettings.Authority;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateAudience = false
                };
            });

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                policy.RequireAuthenticatedUser()
                    .RequireClaim("scope", AuthScope.Read)
                    .RequireClaim("scope", AuthScope.Write));

        return builder;
    }
}