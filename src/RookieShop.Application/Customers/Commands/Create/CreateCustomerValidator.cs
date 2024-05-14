using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Customers.Commands.Create;

public sealed class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(DataLength.Medium);

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(DataLength.Medium)
            .EmailAddress();

        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(DataLength.Small);

        RuleFor(x => x.Gender)
            .IsInEnum();

        RuleFor(x => x.AccountId)
            .MaximumLength(DataLength.Medium);
    }
}