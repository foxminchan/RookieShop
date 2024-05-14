using FluentValidation;

namespace RookieShop.Application.Products.Queries.Get;

public sealed class GetProductValidator : AbstractValidator<GetProductQuery>
{
    public GetProductValidator() => RuleFor(x => x.Id).NotEmpty();
}