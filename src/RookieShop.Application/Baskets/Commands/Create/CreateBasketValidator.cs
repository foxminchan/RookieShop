using FluentValidation;

namespace RookieShop.Application.Baskets.Commands.Create;

public sealed class CreateBasketValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketValidator()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty();

        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .GreaterThan(0);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);
    }
}