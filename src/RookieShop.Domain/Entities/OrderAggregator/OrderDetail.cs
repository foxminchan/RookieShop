using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator;

public sealed class OrderDetail : EntityBase
{
    /// <summary>
    ///     EF mapping constructor
    /// </summary>
    public OrderDetail()
    {
    }

    public OrderDetail(int quantity, decimal price)
    {
        Quantity = Guard.Against.NegativeOrZero(quantity);
        Price = Guard.Against.Negative(price);
    }

    public ProductId ProductId { get; set; }
    public OrderId OrderId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; } = new();
    public Order Order { get; set; } = new();
}