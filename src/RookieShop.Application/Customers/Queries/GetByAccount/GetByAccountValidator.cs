using FluentValidation;

namespace RookieShop.Application.Customers.Queries.GetByAccount;

public sealed class GetByAccountValidator : AbstractValidator<GetByAccountQuery>
{
    public GetByAccountValidator() => RuleFor(x => x.AccountId).NotEmpty();
}