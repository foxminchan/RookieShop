using Ardalis.Specification;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;

namespace RookieShop.Domain.Entities.OrderAggregator.Specifications;

public sealed class OrderFilterSpec : Specification<Order>
{
    public OrderFilterSpec(int pageIndex, int pageSize, OrderStatus? status, CustomerId? userId, string? search = null)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        if (userId is not null)
            Query.Where(order => order.CustomerId == userId);

        if (status is not null)
            Query.Where(order => order.OrderStatus == status);

        if (!string.IsNullOrEmpty(search))
            Query.Where(order => order.Id.ToString().Contains(search));

        Query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .OrderBy(x => x.Id);
    }
}