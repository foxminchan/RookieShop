using FluentValidation;

namespace RookieShop.Application.Products.Queries.Search;

public sealed class SearchProductValidator : AbstractValidator<SearchProductQuery>
{
    public SearchProductValidator()
    {
        RuleFor(x => x.Context).NotEmpty();
        RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0);
    }
}