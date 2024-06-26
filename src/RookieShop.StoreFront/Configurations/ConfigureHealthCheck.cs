﻿using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RookieShop.Storefront.Options;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureHealthCheck
{
    public static IHostApplicationBuilder AddHealthCheck(this IHostApplicationBuilder builder, AppSettings appSettings)
    {
        Uri url = new(string.Concat(appSettings.BaseApiEndpoint, "/categories"));

        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy())
            .AddUrlGroup(url, "api-check", tags: ["api"]);

        return builder;
    }

    public static void MapHealthCheck(this WebApplication app) =>
        app.UseHealthChecks("/hc",
            new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    var resultObject = new
                    {
                        status = report.Status.ToString(),
                        errors = report.Entries.Select(e => new
                        {
                            key = e.Key,
                            value = Enum.GetName(typeof(HealthStatus), e.Value.Status)
                        })
                    };

                    var result = JsonSerializer.Serialize(resultObject);

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                }
            });
}