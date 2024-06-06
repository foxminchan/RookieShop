using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Orders.Commands.Create;

public sealed class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.PaymentMethod)
            .IsInEnum();

        RuleFor(x => x.Last4)
            .MaximumLength(DataLength.Micro - 1);

        RuleFor(x => x.BrandName)
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.Street)
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.City)
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.Province)
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.AccountId)
            .NotEmpty();
    }
}