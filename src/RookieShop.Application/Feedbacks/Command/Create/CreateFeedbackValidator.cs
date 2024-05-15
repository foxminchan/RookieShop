using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Feedbacks.Command.Create;

public sealed class CreateFeedbackValidator : AbstractValidator<CreateFeedbackCommand>
{
    public CreateFeedbackValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5);

        RuleFor(x => x.Content)
            .MaximumLength(DataLength.Max);
    }
}