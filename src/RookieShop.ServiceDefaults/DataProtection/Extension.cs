﻿using Ardalis.GuardClauses;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace RookieShop.ServiceDefaults.DataProtection;

public static class Extension
{
    public static IHostApplicationBuilder AddRedisDataProtection(this IHostApplicationBuilder builder)
    {
        var conn = builder.Configuration.GetConnectionString("redis");

        Guard.Against.NullOrEmpty(conn);

        builder.Services.AddDataProtection()
            .SetDefaultKeyLifetime(TimeSpan.FromDays(14))
            .SetApplicationName(nameof(RookieShop))
            .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(conn), nameof(DataProtectionProvider));

        return builder;
    }
}