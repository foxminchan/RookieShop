using FluentValidation;

namespace RookieShop.Infrastructure.GenAi.OpenAi.Settings;

public sealed class OpenAiSettingsValidator : AbstractValidator<OpenAiSettings>
{
    public OpenAiSettingsValidator()
    {
        RuleFor(x => x.ApiKey).NotEmpty();
        RuleFor(x => x.EmbeddingModel).NotEmpty();
    }
}