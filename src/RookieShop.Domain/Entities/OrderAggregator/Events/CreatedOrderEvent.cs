using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator.Events;

public sealed class CreatedOrderEvent(Guid accountId, Order order, string email) : EventBase
{
    public Guid AccountId { get; set; } = accountId;
    public Order Order { get; set; } = order;
    public string Email { get; set; } = email;
}