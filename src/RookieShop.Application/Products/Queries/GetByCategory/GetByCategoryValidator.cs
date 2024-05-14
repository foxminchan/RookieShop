using FluentValidation;

namespace RookieShop.Application.Products.Queries.GetByCategory;

public sealed class GetByCategoryValidator : AbstractValidator<GetByCategoryQuery>
{
    public GetByCategoryValidator()
    {
        RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).NotEmpty();
    }
}