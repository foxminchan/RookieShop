using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RookieShop.Infrastructure.Cache.Redis;
using RookieShop.Infrastructure.Cache.Redis.Internal;
using RookieShop.Infrastructure.Cache.Redis.Settings;
using StackExchange.Redis;

namespace RookieShop.Infrastructure.Cache;

public static class Extension
{
    public static IHostApplicationBuilder AddRedisCache(this IHostApplicationBuilder builder)
    {
        if (builder.Services.Contains(ServiceDescriptor.Singleton<IRedisService, RedisService>()))
            return builder;

        builder.Services.AddSingleton<IConfigureOptions<RedisSettings>, RedisSettingsService>();

        var redisSettings = builder.Configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>();

        Guard.Against.Null(redisSettings);

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = builder.Configuration[redisSettings.Prefix];
            options.ConfigurationOptions = GetRedisConfigurationOptions(redisSettings);
        });

        builder.Services.AddSingleton<IRedisService, RedisService>();

        return builder;
    }

    private static ConfigurationOptions GetRedisConfigurationOptions(RedisSettings redisSettings)
    {
        ConfigurationOptions configurationOptions = new()
        {
            ConnectTimeout = redisSettings.ConnectTimeout,
            SyncTimeout = redisSettings.SyncTimeout,
            ConnectRetry = redisSettings.ConnectRetry,
            AbortOnConnectFail = redisSettings.AbortOnConnectFail,
            ReconnectRetryPolicy = new ExponentialRetry(redisSettings.DeltaBackOff),
            KeepAlive = 5,
            Ssl = redisSettings.Ssl
        };

        if (!string.IsNullOrWhiteSpace(redisSettings.Password)) configurationOptions.Password = redisSettings.Password;

        foreach (var endpoint in redisSettings.Url.Split(',')) configurationOptions.EndPoints.Add(endpoint);

        return configurationOptions;
    }
}