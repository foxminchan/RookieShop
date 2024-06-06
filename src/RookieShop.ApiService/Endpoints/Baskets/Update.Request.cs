using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed record UpdateBasketRequest(Guid AccountId, ProductId ProductId, int Quantity);