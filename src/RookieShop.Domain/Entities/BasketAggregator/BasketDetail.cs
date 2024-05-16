using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Domain.Entities.BasketAggregator;

public sealed class BasketDetail(ProductId id, int quantity, decimal price)
{
    public ProductId Id { get; set; } = Guard.Against.Null(id);
    public int Quantity { get; set; } = Guard.Against.OutOfRange(quantity, nameof(quantity), 1, int.MaxValue);
    public decimal Price { get; set; } = Guard.Against.OutOfRange(price, nameof(price), 0, decimal.MaxValue);

    public decimal ToPrice() => Quantity * Price;

    public void Update(int quantity, decimal price)
    {
        Quantity = Guard.Against.OutOfRange(quantity, nameof(quantity), 1, int.MaxValue);
        Price = Guard.Against.OutOfRange(price, nameof(price), 0, decimal.MaxValue);
    }
}