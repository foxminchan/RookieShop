using FluentValidation;

namespace RookieShop.Infrastructure.Merchant.Stripe.Settings;

public sealed class StripeSettingsValidator : AbstractValidator<StripeSettings>
{
    public StripeSettingsValidator() => RuleFor(x => x.SecretKey).NotEmpty();
}