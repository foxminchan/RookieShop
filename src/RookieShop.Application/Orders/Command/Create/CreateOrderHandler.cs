using Ardalis.Result;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Command.Create;

public sealed class CreateOrderHandler() : ICommandHandler<CreateOrderCommand, Result<OrderId>>
{
    public async Task<Result<OrderId>> Handle(CreateOrderCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}