using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed record CreateProductRequest(
    string Name,
    string? Description,
    int Quantity,
    decimal Price,
    decimal PriceSale,
    IFormFile? ProductImages,
    CategoryId? CategoryId = null);