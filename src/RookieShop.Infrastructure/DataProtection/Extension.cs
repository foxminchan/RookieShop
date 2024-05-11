using Ardalis.GuardClauses;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Cache.Redis.Settings;
using StackExchange.Redis;

namespace RookieShop.Infrastructure.DataProtection;

public static class Extension
{
    public static IHostApplicationBuilder AddRedisDataProtection(this IHostApplicationBuilder builder)
    {
        var redis = builder.Configuration
            .GetSection(nameof(RedisSettings))
            .Get<RedisSettings>();

        Guard.Against.Null(redis);

        var conn = redis.GetConnectionString();

        builder.Services.AddDataProtection()
            .SetDefaultKeyLifetime(TimeSpan.FromDays(14))
            .SetApplicationName(nameof(RookieShop))
            .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(conn), nameof(DataProtection));

        return builder;
    }
}