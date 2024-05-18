using FluentValidation;

namespace RookieShop.Application.Reports.Queries.DiffRevenueByMonth;

public sealed class DiffRevenueByMonthReportValidator : AbstractValidator<DiffRevenueByMonthQuery>
{
    public DiffRevenueByMonthReportValidator()
    {
        RuleFor(x => x.SourceMonth)
            .NotEmpty()
            .InclusiveBetween(1, 12);

        RuleFor(x => x.SourceYear)
            .NotEmpty()
            .InclusiveBetween(2000, 2100);

        RuleFor(x => x.TargetMonth)
            .NotEmpty()
            .InclusiveBetween(1, 12);

        RuleFor(x => x.TargetYear)
            .NotEmpty()
            .InclusiveBetween(2000, 2100);
    }
}