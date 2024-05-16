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

    public OrderDetail(ProductId productId, int quantity, decimal price)
    {
        ProductId = Guard.Against.Null(productId);
        Quantity = Guard.Against.OutOfRange(quantity, nameof(quantity), 1, int.MaxValue);
        Price = Guard.Against.OutOfRange(price, nameof(price), 0, decimal.MaxValue);
    }

    public ProductId ProductId { get; set; }
    public OrderId OrderId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; } = new();
    public Order Order { get; set; } = new();

    public decimal ToPrice() => Price * Quantity;
}