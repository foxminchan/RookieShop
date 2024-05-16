using FluentValidation;

namespace RookieShop.Application.Orders.Queries.Get;

public sealed class GetOrderValidator : AbstractValidator<GetOrderQuery>
{
    public GetOrderValidator() => RuleFor(x => x.OrderId).NotEmpty();
}