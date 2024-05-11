using Ardalis.GuardClauses;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Cache.Redis.Settings;

namespace RookieShop.Infrastructure.HealthCheck;

public static class Extension
{
    public static IHostApplicationBuilder AddHealthCheck(this IHostApplicationBuilder builder)
    {
        var dbConn = builder.Configuration.GetConnectionString("DefaultConnection");
        Guard.Against.Null(dbConn, message: "Connection string 'DefaultConnection' not found.");

        var cacheConn = builder.Configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>()?.Url;
        Guard.Against.Null(cacheConn, message: "Redis Url not found.");

        var isConn = builder.Configuration.GetValue<string>("OAuth:Authority");
        Guard.Against.Null(isConn, message: "OAuth Authority not found.");

        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddNpgSql(dbConn, name: "Postgres", tags: ["database"])
            .AddRedis(cacheConn, "Redis", tags: ["redis"])
            .AddIdentityServer(new Uri(isConn), name: "Identity Server", tags: ["identity-server"]);

        builder.Services
            .AddHealthChecksUI(options =>
            {
                options.AddHealthCheckEndpoint("Health Check API", "/hc");
                options.SetEvaluationTimeInSeconds(60);
                options.DisableDatabaseMigrations();
            })
            .AddInMemoryStorage();

        return builder;
    }

    public static void MapHealthCheck(this WebApplication app)
    {
        app.MapHealthChecks("/hc",
            new()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                AllowCachingResponses = false
            });

        app.MapHealthChecks("/alive", new() { Predicate = r => r.Name.Contains("self") });

        app.MapHealthChecksUI(options => options.UIPath = "/hc-ui");
    }
}