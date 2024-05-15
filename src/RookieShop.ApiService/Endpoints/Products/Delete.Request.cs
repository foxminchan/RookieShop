using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed record DeleteProductRequest(ProductId Id);