using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Baskets.Queries.Get;

public sealed class GetBasketValidator : AbstractValidator<GetBasketQuery>
{
    public GetBasketValidator() => RuleFor(x => x.AccountId).NotEmpty().MaximumLength(DataLength.Medium);
}