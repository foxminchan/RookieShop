using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Events;
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

    public Order(PaymentMethod paymentMethod, string? last4, string? brand, string? chargeId, string? street,
        string? city, string? province, CustomerId customerId, OrderStatus orderStatus)
    {
        PaymentMethod = Guard.Against.EnumOutOfRange(paymentMethod);
        Card = Card.Create( brand, last4, chargeId);
        ShippingAddress = ShippingAddress.Create(street, city, province);
        CustomerId = Guard.Against.Default(customerId);
        OrderStatus = Guard.Against.EnumOutOfRange(orderStatus);
    }

    public OrderId Id { get; set; }
    public Card? Card { get; set; }
    public ShippingAddress? ShippingAddress { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
    public CustomerId CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = [];

    public void AddOrderDetail(Guid accountId, Order order, string email)
    {
        Guard.Against.Null(order);

        RegisterDomainEvent(new CreatedOrderEvent(accountId, order, email));
    }

    public void UpdateOrderStatus(Order order)
    {
        Guard.Against.Null(order);

        RegisterDomainEvent(new UpdatedOrderEvent(order));
    }

    public decimal TotalPrice() => OrderDetails.Sum(x => x.ToPrice());

    private void AddOrderDetail(OrderDetail orderDetail) => OrderDetails.Add(orderDetail);

    public void Update(OrderStatus status) => OrderStatus = Guard.Against.EnumOutOfRange(status);

    public static class Factory
    {
        public static Order Create(
            PaymentMethod paymentMethod,
            string? last4,
            string? brand,
            string? chargeId,
            string? street,
            string? city,
            string? province,
            CustomerId customerId,
            OrderStatus orderStatus,
            List<OrderDetail> orderDetails)

        {
            Order order = new(paymentMethod, last4, brand, chargeId, street, city, province, customerId, orderStatus);

            Guard.Against.NullOrEmpty(orderDetails);

            foreach (var orderDetail in orderDetails)
            {
                order.AddOrderDetail(orderDetail);
            }

            return order;
        }
    }
}