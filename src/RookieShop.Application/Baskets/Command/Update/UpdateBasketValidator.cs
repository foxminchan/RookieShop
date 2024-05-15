using FluentValidation;

namespace RookieShop.Application.Baskets.Command.Update;

public sealed class UpdateBasketValidator : AbstractValidator<UpdateBasketCommand>
{
    public UpdateBasketValidator()
    {
        RuleFor(x => x.AccountId)
            .NotEmpty();

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