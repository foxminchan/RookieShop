using FluentValidation;
using RookieShop.Domain.Constants;

namespace RookieShop.Application.Customers.Commands.Update;

public sealed class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

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
    }
}