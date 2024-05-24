using Ardalis.GuardClauses;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Identity.Settings;

namespace RookieShop.Infrastructure.HealthCheck;

public static class Extension
{
    public static IHostApplicationBuilder AddHealthCheck(this IHostApplicationBuilder builder)
    {
        var openIdSettings = builder.Configuration.GetSection(nameof(OpenIdSettings)).Get<OpenIdSettings>();
        Guard.Against.Null(openIdSettings);

        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddIdentityServer(new Uri(openIdSettings.Authority), name: "Identity Server", tags: ["identity-server"]);

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
        app.UseHealthChecks("/hc", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            ResultStatusCodes =
            {
                [HealthStatus.Healthy] = StatusCodes.Status200OK,
                [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
            }
        });

        app.MapHealthChecks("/alive", new() { Predicate = r => r.Name.Contains("self") });

        app.UseHealthChecksUI(options => options.UIPath = "/hc-ui");
    }
}