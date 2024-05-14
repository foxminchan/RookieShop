using FluentValidation;

namespace RookieShop.Application.Customers.Queries.Get;

public sealed class GetCustomerValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerValidator() => RuleFor(x => x.Id).NotEmpty();
}