using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Domain.Entities.BasketAggregator;

public sealed class BasketDetail
{
    public ProductId Id { get; set; } = new(Guid.NewGuid());
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}