using FluentValidation;

namespace RookieShop.Application.Reports.Queries.RevenueYear;

public sealed class RevenueYearValidator : AbstractValidator<RevenueYearQuery>
{
    public RevenueYearValidator() => RuleFor(x => x.Year).NotEmpty().GreaterThan(2000);
}