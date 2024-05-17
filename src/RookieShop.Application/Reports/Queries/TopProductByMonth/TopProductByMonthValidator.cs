using FluentValidation;

namespace RookieShop.Application.Reports.Queries.TopProductByMonth;

public sealed class TopProductByMonthValidator : AbstractValidator<TopProductByMonthQuery>
{
    public TopProductByMonthValidator()
    {
        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12);

        RuleFor(x => x.Year)
            .InclusiveBetween(2000, 2100);

        RuleFor(x => x.Limit)
            .InclusiveBetween(1, 100);
    }
}