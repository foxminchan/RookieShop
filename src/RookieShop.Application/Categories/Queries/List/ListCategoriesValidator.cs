using FluentValidation;

namespace RookieShop.Application.Categories.Queries.List;

public sealed class ListCategoriesValidator : AbstractValidator<ListCategoriesQuery>
{
    public ListCategoriesValidator()
    {
        RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0);
    }
}