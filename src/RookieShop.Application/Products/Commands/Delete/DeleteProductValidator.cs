using FluentValidation;

namespace RookieShop.Application.Products.Commands.Delete;

public sealed class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator() => RuleFor(x => x.Id).NotEmpty();
}