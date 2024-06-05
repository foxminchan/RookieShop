using FluentValidation;

namespace RookieShop.Application.Reports.Queries.CustomersGrownByMonth;

public sealed class CustomersGrownByMonthValidator : AbstractValidator<CustomersGrownByMonthQuery>
{
    public CustomersGrownByMonthValidator()
    {
        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12);

        RuleFor(x => x.Year)
            .GreaterThan(2000);
    }
}