﻿using System.Security.Claims;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace RookieShop.Infrastructure.RateLimiter;

public static class RateLimitExtensions
{
    private const string Policy = "PerUserRatelimit";

    public static IHostApplicationBuilder AddRateLimiting(this IHostApplicationBuilder builder)
    {
        builder.Services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddPolicy(Policy, context =>
            {
                var username = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

                return RateLimitPartition.GetTokenBucketLimiter(username,
                    _ => new()
                    {
                        ReplenishmentPeriod = TimeSpan.FromSeconds(10),
                        AutoReplenishment = true,
                        TokenLimit = 100,
                        TokensPerPeriod = 100,
                        QueueLimit = 100
                    });
            });
        });

        return builder;
    }

    public static IEndpointConventionBuilder RequirePerUserRateLimit(this IEndpointConventionBuilder builder)
        => builder.RequireRateLimiting(Policy);
}