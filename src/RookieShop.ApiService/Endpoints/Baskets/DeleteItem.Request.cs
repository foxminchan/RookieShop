using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed record DeleteItemRequest(Guid AccountId, ProductId ProductId);