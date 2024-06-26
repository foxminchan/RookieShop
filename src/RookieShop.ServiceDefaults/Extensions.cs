using Ardalis.ListStartupServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ServiceDiscovery;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using RookieShop.ServiceDefaults.DataProtection;
using RookieShop.ServiceDefaults.OpenTelemetry.ActivityScope;
using RookieShop.ServiceDefaults.OpenTelemetry.Metrics;

namespace RookieShop.ServiceDefaults;

public static class Extensions
{
    public static IHostApplicationBuilder AddServiceDefaults(this IHostApplicationBuilder builder)
    {
        builder.ConfigureOpenTelemetry();

        builder.Services.AddServiceDiscovery();

        builder.Services.ConfigureHttpClientDefaults(http =>
        {
            http.AddStandardResilienceHandler();
            http.AddServiceDiscovery();
        });

        builder.Services.Configure<ServiceDiscoveryOptions>(options => { options.AllowedSchemes = ["https"]; });

        builder.AddRedisDataProtection();

        builder.Services.Configure<ServiceConfig>(config => config.Services = [.. builder.Services]);

        builder.Services.AddSingleton<IActivityScope, ActivityScope>();

        builder.Services.AddSingleton<CommandHandlerMetrics>();

        builder.Services.AddSingleton<QueryHandlerMetrics>();

        return builder;
    }

    public static IHostApplicationBuilder ConfigureOpenTelemetry(this IHostApplicationBuilder builder)
    {
        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        builder.Services.AddOpenTelemetry()
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddRuntimeInstrumentation()
                    .AddMeter("Marten")
                    .AddMeter(ActivitySourceProvider.DefaultSourceName);
            })
            .WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation(b => b.SetDbStatementForText = true)
                    .AddQuartzInstrumentation()
                    .AddSource("Marten")
                    .AddSource(ActivitySourceProvider.DefaultSourceName);
            });

        builder.AddOpenTelemetryExporters();

        return builder;
    }

    private static void AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
    {
        var useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

        if (useOtlpExporter) builder.Services.AddOpenTelemetry().UseOtlpExporter();
    }
}