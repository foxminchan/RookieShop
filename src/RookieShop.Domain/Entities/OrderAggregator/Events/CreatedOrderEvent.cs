using Ardalis.GuardClauses;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator.Events;

public sealed class CreatedOrderEvent(Guid accountId, Order order, string email) : EventBase
{
    public Guid AccountId { get; set; } = Guard.Against.Default(accountId);
    public Order Order { get; set; } = Guard.Against.Null(order);
    public string Email { get; set; } = Guard.Against.NullOrEmpty(email);
}