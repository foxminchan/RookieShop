using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Baskets.Command.Create;

public sealed class CreateBasketValidator : AbstractValidator<CreateBasketCommand>
{
    public CreateBasketValidator()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty()
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.BasketDetails)
            .ForEach(d =>
                d.ChildRules(b =>
                {
                    b.RuleFor(x => x.Id)
                        .NotEmpty();

                    b.RuleFor(x => x.Quantity)
                        .GreaterThan(0);

                    b.RuleFor(x => x.Price)
                        .GreaterThanOrEqualTo(0);
                }))
            .NotEmpty();
    }
}