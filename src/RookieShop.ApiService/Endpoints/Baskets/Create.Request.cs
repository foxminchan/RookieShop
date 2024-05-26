using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class CreateBasketRequest
{
    public Guid AccountId { get; set; }
    public ProductId ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}