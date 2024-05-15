using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed record GetProductRequest(ProductId Id);