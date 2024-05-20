using FluentValidation;

namespace RookieShop.Infrastructure.Merchant.Settings;

public sealed class StripeSettingsValidator : AbstractValidator<StripeSettings>
{
    public StripeSettingsValidator() => RuleFor(x => x.SecretKey).NotEmpty();
}