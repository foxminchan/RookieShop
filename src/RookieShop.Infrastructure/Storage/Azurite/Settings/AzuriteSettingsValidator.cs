using FluentValidation;

namespace RookieShop.Infrastructure.Storage.Azurite.Settings;

public sealed class AzuriteSettingsValidator : AbstractValidator<AzuriteSettings>
{
    public AzuriteSettingsValidator()
    {
        RuleFor(x => x.ConnectionString).NotEmpty();
        RuleFor(x => x.ContainerName).NotEmpty();
    }
}