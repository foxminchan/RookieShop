using FluentValidation;

namespace RookieShop.Application.Orders.Command.Update;

public sealed class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.OrderStatus).IsInEnum();
    }
}