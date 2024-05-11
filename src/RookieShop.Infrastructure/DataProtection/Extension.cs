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
        builder.Services.AddDataProtection()
            .SetDefaultKeyLifetime(TimeSpan.FromDays(14))
            .SetApplicationName(builder.Configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>()!.Prefix)
            .PersistKeysToStackExchangeRedis(
                ConnectionMultiplexer.Connect(builder.Configuration.GetSection(nameof(RedisSettings))
                    .Get<RedisSettings>()!.Url), nameof(DataProtection));

        return builder;
    }
}