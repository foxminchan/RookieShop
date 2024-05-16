using Ardalis.Result;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Queries.List;

public sealed class ListOrdersHandler(IReadRepository<Order> repository)
    : IQueryHandler<ListOrdersQuery, PagedResult<IEnumerable<OrderDto>>>
{
    public async Task<PagedResult<IEnumerable<OrderDto>>> Handle(ListOrdersQuery request,
        CancellationToken cancellationToken)
    {
        OrderFilterSpec spec = new(request.PageIndex, request.PageSize, request.Status, request.UserId);

        var orders = await repository.ListAsync(spec, cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, orders.ToOrderDto());
    }
}