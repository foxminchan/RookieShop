using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Orders.Command.Create;

public sealed class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.PaymentMethod)
            .IsInEnum();

        RuleFor(x => x.Number)
            .CreditCard();

        RuleFor(x => x.ExpiryYear)
            .MaximumLength(DataLength.Micro - 1);

        RuleFor(x => x.ExpiryMonth)
            .Must(month =>
            {
                if (string.IsNullOrEmpty(month))
                    return true;

                if (!int.TryParse(month, out var monthNumber))
                    return false;
                return monthNumber is >= 1 and <= 12;
            });

        RuleFor(x => x.Cvc)
            .MaximumLength(DataLength.Micro - 1);

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