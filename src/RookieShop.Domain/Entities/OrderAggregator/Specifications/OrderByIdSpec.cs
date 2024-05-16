using Ardalis.Specification;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;

namespace RookieShop.Domain.Entities.OrderAggregator.Specifications;

public sealed class OrderByIdSpec : Specification<Order>
{
    public OrderByIdSpec(OrderId orderId) => Query.Where(order => order.Id == orderId);
}