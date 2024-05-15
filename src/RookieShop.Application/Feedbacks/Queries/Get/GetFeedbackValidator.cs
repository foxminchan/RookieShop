using FluentValidation;

namespace RookieShop.Application.Feedbacks.Queries.Get;

public sealed class GetFeedbackValidator : AbstractValidator<GetFeedbackQuery>
{
    public GetFeedbackValidator() => RuleFor(x => x.Id).NotEmpty();
}