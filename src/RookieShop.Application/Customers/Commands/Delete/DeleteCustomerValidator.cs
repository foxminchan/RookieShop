using FluentValidation;

namespace RookieShop.Application.Customers.Commands.Delete;

public sealed class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerValidator() => RuleFor(x => x.Id).NotEmpty();
}