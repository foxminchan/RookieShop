using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Baskets.Command.Delete;

public sealed class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketValidator() => RuleFor(x => x.AccountId).NotEmpty().MaximumLength(DataLength.Medium);
}