using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Feedbacks.Command.Update;

public sealed class UpdateFeedbackValidator : AbstractValidator<UpdateFeedbackCommand>
{
    public UpdateFeedbackValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5);

        RuleFor(x => x.Content)
            .MaximumLength(DataLength.Max);
    }
}