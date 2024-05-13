using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.ValueObjects;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator;

public sealed class Order : EntityBase, IAggregateRoot
{
    /// <summary>
    ///     EF mapping constructor
    /// </summary>
    public Order()
    {
    }

    public Order(PaymentMethod paymentMethod, string? last4, string? brand, string? chargeId)
    {
        PaymentMethod = paymentMethod;
        Card = Card.Create(last4, brand, chargeId);
    }

    public OrderId Id { get; set; }
    public Card? Card { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
    public Customer? Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];
}