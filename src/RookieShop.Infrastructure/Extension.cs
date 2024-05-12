using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Domain.Constants;
using RookieShop.Infrastructure.Cache;
using RookieShop.Infrastructure.DataProtection;
using RookieShop.Infrastructure.Email;
using RookieShop.Infrastructure.GenAi;
using RookieShop.Infrastructure.HealthCheck;
using RookieShop.Infrastructure.Lock;
using RookieShop.Infrastructure.Merchant;
using RookieShop.Infrastructure.OpenTelemetry;
using RookieShop.Infrastructure.RateLimiter;
using RookieShop.Infrastructure.Storage;
using RookieShop.Infrastructure.Swagger;
using RookieShop.Infrastructure.Validator;
using RookieShop.Infrastructure.Versioning;

namespace RookieShop.Infrastructure;

public static class Extension
{
    private static IHostApplicationBuilder AddCustomCors(this IHostApplicationBuilder builder, string corsName = "api")
    {
        var clientEndpoints = new[]
        {
            builder.Configuration.GetValue<string>("Client:StoreFront") ?? string.Empty,
            builder.Configuration.GetValue<string>("Client:BackOffice") ?? string.Empty
        };

        builder.Services.AddCors(options => options.AddPolicy(corsName,
            policy => policy
                .WithOrigins(clientEndpoints)
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                .AllowAnyHeader()
                .AllowAnyMethod()
        ));

        return builder;
    }

    private static IApplicationBuilder UseCustomCors(this IApplicationBuilder app, string corsName = "api")
        => app.UseCors(corsName);

    private static IHostApplicationBuilder AddIdentity(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Audience = nameof(RookieShop).ToLowerInvariant();
                options.Authority = builder.Configuration.GetValue<string>("OAuth:Authority");
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

    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder
            .AddValidator()
            .AddVersioning()
            .AddOpenApi()
            .AddCustomCors()
            .AddRateLimiting()
            .AddIdentity()
            .AddRedisCache()
            .AddRedisDataProtection()
            .AddRedisDistributedLock()
            .AddStorage()
            .AddEmail()
            .AddHealthCheck()
            .AddStripeService()
            .AddGenAi()
            .ConfigureOpenTelemetry();

        return builder;
    }

    public static IApplicationBuilder MapInfrastructure(this WebApplication app)
    {
        app
            .UseCustomCors()
            .UseRateLimiter()
            .UseAuthentication()
            .UseAuthorization();

        app.UseOpenApi()
            .MapHealthCheck();

        return app;
    }
}