using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RookieShop.Infrastructure.Validator;

namespace RookieShop.Infrastructure.Cache.Redis.Settings;

public sealed class RedisSettingsService(IHostApplicationBuilder builder) : IConfigureNamedOptions<RedisSettings>
{
    public void Configure(RedisSettings options) =>
        builder.Services.AddOptionsWithValidateOnStart<RedisSettings>()
            .Bind(builder.Configuration.GetSection(nameof(RedisSettings)))
            .ValidateFluentValidation();

    public void Configure(string? name, RedisSettings options) => Configure(options);
}