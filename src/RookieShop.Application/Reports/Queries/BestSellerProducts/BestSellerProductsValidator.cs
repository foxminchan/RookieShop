using FluentValidation;

namespace RookieShop.Application.Reports.Queries.BestSellerProducts;

public sealed class BestSellerProductsValidator : AbstractValidator<BestSellerProductsQuery>
{
    public BestSellerProductsValidator()
    {
        RuleFor(x => x.Top)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.From)
            .LessThan(x => x.To);

        RuleFor(x => x.To)
            .GreaterThan(x => x.From);
    }
}