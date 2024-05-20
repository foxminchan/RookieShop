using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Cache;
using RookieShop.Infrastructure.DataProtection;
using RookieShop.Infrastructure.Email;
using RookieShop.Infrastructure.HealthCheck;
using RookieShop.Infrastructure.Identity;
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
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder
            .AddValidator()
            .AddVersioning()
            .AddRateLimiting()
            .AddIdentity()
            .AddOpenApi()
            .AddRedisCache()
            .AddRedisDataProtection()
            .AddRedisDistributedLock()
            .AddStorage()
            .AddEmail()
            .AddHealthCheck()
            .AddStripeService()
            .ConfigureOpenTelemetry();

        return builder;
    }

    public static IApplicationBuilder MapInfrastructure(this WebApplication app)
    {
        app.UseRateLimiter()
            .UseAuthentication()
            .UseAuthorization();

        app.UseOpenApi()
            .MapHealthCheck();

        return app;
    }
}