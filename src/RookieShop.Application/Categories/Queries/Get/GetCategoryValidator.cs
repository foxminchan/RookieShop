using FluentValidation;

namespace RookieShop.Application.Categories.Queries.Get;

public sealed class GetCategoryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryValidator() => RuleFor(x => x.Id).NotEmpty();
}