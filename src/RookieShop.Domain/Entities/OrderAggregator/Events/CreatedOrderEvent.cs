using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator.Events;

public sealed class CreatedOrderEvent(Guid? accountId, OrderId orderId) : EventBase
{
    public Guid? AccountId { get; set; } = accountId;
    public OrderId OrderId { get; set; } = orderId;
}