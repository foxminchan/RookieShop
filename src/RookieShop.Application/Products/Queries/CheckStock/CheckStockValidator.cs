using FluentValidation;

namespace RookieShop.Application.Products.Queries.CheckStock;

public sealed class CheckStockValidator : AbstractValidator<CheckStockQuery>
{
    public CheckStockValidator() => RuleFor(x => x.Requests).NotEmpty();
}