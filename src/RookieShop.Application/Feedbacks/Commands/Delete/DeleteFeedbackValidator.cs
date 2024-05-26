using FluentValidation;

namespace RookieShop.Application.Feedbacks.Commands.Delete;

public sealed class DeleteFeedbackValidator : AbstractValidator<DeleteFeedbackCommand>
{
    public DeleteFeedbackValidator() => RuleFor(x => x.Id).NotEmpty();
}