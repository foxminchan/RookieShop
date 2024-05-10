using FluentValidation;

namespace RookieShop.Infrastructure.Cache.Redis.Settings;

public sealed class RedisSettingsValidator : AbstractValidator<RedisSettings>
{
    public RedisSettingsValidator()
    {
        RuleFor(x => x.ConnectRetry).GreaterThan((byte)0);
        RuleFor(x => x.ConnectTimeout).GreaterThan(0);
        RuleFor(x => x.DeltaBackOff).GreaterThan(0);
        RuleFor(x => x.RedisDefaultSlidingExpirationInSecond).GreaterThan(0);
        RuleFor(x => x.SyncTimeout).GreaterThan(0);
        RuleFor(x => x.Url).NotEmpty();
        RuleFor(x => x.Prefix).NotEmpty();
    }
}