using FluentValidation;

namespace RookieShop.Application.Categories.Commands.Delete;

public sealed class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryValidator() => RuleFor(x => x.Id).NotEmpty();
}