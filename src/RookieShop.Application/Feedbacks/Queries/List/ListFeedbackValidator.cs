using FluentValidation;

namespace RookieShop.Application.Feedbacks.Queries.List;

public sealed class ListFeedbackValidator : AbstractValidator<ListFeedbackQuery>
{
    public ListFeedbackValidator()
    {
        RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0);
    }
}