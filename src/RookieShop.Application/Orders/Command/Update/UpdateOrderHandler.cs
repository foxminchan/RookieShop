using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Command.Update;

public sealed class UpdateOrderHandler(IRepository<Order> repository)
    : ICommandHandler<UpdateOrderCommand, Result<OrderDto>>
{
    public async Task<Result<OrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, order);

        order.Update(request.OrderStatus);

        await repository.UpdateAsync(order, cancellationToken);

        order.UpdateOrderStatus(order);

        return order.ToOrderDto();
    }
}