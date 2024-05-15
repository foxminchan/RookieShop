using RookieShop.Domain.Entities.BasketAggregator;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed class UpdateBasketRequest
{
    public Guid AccountId { get; set; }
    public List<BasketDetail> BasketDetails { get; set; } = [];
}