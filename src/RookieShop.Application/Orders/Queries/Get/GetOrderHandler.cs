using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Queries.Get;

public sealed class GetOrderHandler(IReadRepository<Order> repository) : IQueryHandler<GetOrderQuery, Result<OrderDto>>
{
    public async Task<Result<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        OrderByIdSpec spec = new(request.OrderId);

        var order = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        Guard.Against.NotFound(request.OrderId, order);

        return order.ToOrderDto();
    }
}