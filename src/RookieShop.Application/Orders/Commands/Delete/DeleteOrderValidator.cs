using FluentValidation;

namespace RookieShop.Application.Orders.Commands.Delete;

public sealed class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderValidator() => RuleFor(x => x.Id).NotEmpty();
}