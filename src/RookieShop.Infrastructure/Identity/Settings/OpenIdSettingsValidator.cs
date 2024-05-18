using FluentValidation;

namespace RookieShop.Infrastructure.Identity.Settings;

public sealed class OpenIdSettingsValidator : AbstractValidator<OpenIdSettings>
{
    public OpenIdSettingsValidator()
    {
        RuleFor(x => x.Authority).NotEmpty();
        RuleFor(x => x.ClientId).NotEmpty();
        RuleFor(x => x.ClientSecret).NotEmpty();
    }
}