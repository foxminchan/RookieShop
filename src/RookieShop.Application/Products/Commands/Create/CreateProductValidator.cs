using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Products.Commands.Create;

public sealed class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.Description)
            .MaximumLength(DataLength.Max);

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.PriceSale)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(x => x.Price);
    }
}