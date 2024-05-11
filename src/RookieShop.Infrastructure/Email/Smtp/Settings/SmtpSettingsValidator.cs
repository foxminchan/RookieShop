using FluentValidation;

namespace RookieShop.Infrastructure.Email.Smtp.Settings;

public sealed class SmtpSettingsValidator : AbstractValidator<SmtpSettings>
{
    public SmtpSettingsValidator()
    {
        RuleFor(x => x.Host).NotEmpty();
        RuleFor(x => x.Port).InclusiveBetween(1, 65535);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Secret).NotEmpty();
    }
}