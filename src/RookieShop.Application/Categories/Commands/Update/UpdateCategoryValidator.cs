using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Categories.Commands.Update;

public sealed class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.Description)
            .MaximumLength(DataLength.Max);
    }
}