using FluentValidation;

namespace RookieShop.Application.Orders.Queries.List;

public sealed class ListOrdersValidator : AbstractValidator<ListOrdersQuery>
{
    public ListOrdersValidator()
    {
        RuleFor(x => x.PageIndex).GreaterThan(1);
        RuleFor(x => x.PageSize).GreaterThan(0);
    }
}