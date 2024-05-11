using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace RookieShop.Infrastructure.OpenTelemetry;

public static class Extension
{
    public static IHostApplicationBuilder ConfigureOpenTelemetry(this IHostApplicationBuilder builder)
    {
        builder.Logging.AddOpenTelemetry(logging =>
        {
            logging.IncludeFormattedMessage = true;
            logging.IncludeScopes = true;
        });

        builder.Services.AddOpenTelemetry()
            .WithTracing(tracing =>
            {
                if (builder.Environment.IsDevelopment()) tracing.SetSampler(new AlwaysOnSampler());

                tracing
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddEntityFrameworkCoreInstrumentation(b => b.SetDbStatementForText = true)
                    .AddRedisInstrumentation()
                    .AddNpgsql();
            })
            .WithMetrics(metrics =>
                metrics
                    .AddRuntimeInstrumentation()
                    .AddMeter("Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel", "System.Net.Http")
            );

        builder.AddOpenTelemetryExporters();

        return builder;
    }

    private static void AddOpenTelemetryExporters(this IHostApplicationBuilder builder)
    {
        var useOtlpExporter = !string.IsNullOrWhiteSpace(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]);

        var resourceBuilder = ResourceBuilder
            .CreateDefault()
            .AddService(
                serviceName: builder.Environment.ApplicationName,
                serviceVersion: "unknown",
                serviceInstanceId: Environment.MachineName);

        if (!useOtlpExporter) return;

        builder.Services.Configure<OpenTelemetryLoggerOptions>(logging =>
            logging.SetResourceBuilder(resourceBuilder).AddOtlpExporter());
        builder.Services.ConfigureOpenTelemetryMeterProvider(metrics =>
            metrics.SetResourceBuilder(resourceBuilder).AddOtlpExporter());
        builder.Services.ConfigureOpenTelemetryTracerProvider(tracing =>
            tracing.SetResourceBuilder(resourceBuilder).AddOtlpExporter());
    }
}