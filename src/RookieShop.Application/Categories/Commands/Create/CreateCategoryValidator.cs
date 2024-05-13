using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Categories.Commands.Create;

public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.Description)
            .MaximumLength(DataLength.Max);
    }
}