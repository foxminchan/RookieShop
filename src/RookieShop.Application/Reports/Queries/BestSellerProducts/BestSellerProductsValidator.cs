using FluentValidation;

namespace RookieShop.Application.Reports.Queries.BestSellerProducts;

public sealed class BestSellerProductsValidator : AbstractValidator<BestSellerProductsQuery>
{
    public BestSellerProductsValidator() => RuleFor(x => x.Top).NotEmpty().GreaterThan(0);
}