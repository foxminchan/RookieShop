using FluentValidation;

namespace RookieShop.Application.Baskets.Commands.Update;

public sealed class UpdateBasketValidator : AbstractValidator<UpdateBasketCommand>
{
    public UpdateBasketValidator()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty();

        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .GreaterThan(0);
    }
}