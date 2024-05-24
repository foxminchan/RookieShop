using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Cache.Redis;
using RookieShop.Infrastructure.Cache.Redis.Internal;

namespace RookieShop.Infrastructure.Cache;

public static class Extension
{
    public static IHostApplicationBuilder AddRedisCache(this IHostApplicationBuilder builder)
    {
        if (builder.Services.Contains(ServiceDescriptor.Singleton<IRedisService, RedisService>()))
            return builder;

        builder.AddRedisClient("redis", settings => settings.DisableHealthChecks = true);

        builder.Services.AddSingleton<IRedisService, RedisService>();

        return builder;
    }
}