using FluentValidation;

namespace RookieShop.Application.Feedbacks.Command.Delete;

public sealed class DeleteFeedbackValidator : AbstractValidator<DeleteFeedbackCommand>
{
    public DeleteFeedbackValidator() => RuleFor(x => x.Id).NotEmpty();
}