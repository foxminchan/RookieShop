using Ardalis.GuardClauses;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Cache.Redis.Settings;
using StackExchange.Redis;

namespace RookieShop.Infrastructure.Lock;

public static class Extension
{
    public static IHostApplicationBuilder AddRedisDistributedLock(this IHostApplicationBuilder builder)
    {
        var redis = builder.Configuration
            .GetSection(nameof(RedisSettings))
            .Get<RedisSettings>();

        Guard.Against.Null(redis);

        var conn = redis.GetConnectionString();

        Guard.Against.Null(conn, message: "Redis Url not found.");

        builder.Services.AddSingleton<IDistributedLockProvider>(_ =>
            new RedisDistributedSynchronizationProvider(ConnectionMultiplexer.Connect(conn).GetDatabase()));

        return builder;
    }
}