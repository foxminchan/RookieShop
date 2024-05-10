﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Cache.Redis;
using RookieShop.Infrastructure.Cache.Redis.Internal;
using RookieShop.Infrastructure.Cache.Redis.Settings;
using StackExchange.Redis;

namespace RookieShop.Infrastructure.Cache;

public static class Extension
{
    public static IServiceCollection AddRedisCache(
        this IHostApplicationBuilder builder,
        Action<RedisSettings>? setupAction = null)
    {
        if (builder.Services.Contains(ServiceDescriptor.Singleton<IRedisService, RedisService>()))
            return builder.Services;

        RedisSettings redisSettings = new();

        builder.Services.AddOptionsWithValidateOnStart<RedisSettings>()
            .Bind(builder.Configuration.GetSection(nameof(RedisSettings)))
            .ValidateDataAnnotations();

        setupAction?.Invoke(redisSettings);

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = builder.Configuration[redisSettings.Prefix];
            options.ConfigurationOptions = GetRedisConfigurationOptions(redisSettings, builder.Configuration);
        });

        builder.Services.AddSingleton<IRedisService, RedisService>();

        return builder.Services;
    }

    private static ConfigurationOptions GetRedisConfigurationOptions(RedisSettings redisSettings, IConfiguration config)
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

        redisSettings.Url = config.GetSection(nameof(RedisSettings)).Get<RedisSettings>()?.Url
                            ?? throw new InvalidOperationException();

        foreach (var endpoint in redisSettings.Url.Split(',')) configurationOptions.EndPoints.Add(endpoint);

        return configurationOptions;
    }
}