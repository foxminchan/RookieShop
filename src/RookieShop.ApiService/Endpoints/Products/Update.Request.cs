using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Enums;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Products;

public sealed record UpdateProductRequest(
    ProductId Id,
    string Name,
    string? Description,
    int Quantity,
    decimal Price,
    decimal PriceSale,
    ProductStatus Status,
    IFormFile? ProductImages,
    bool IsDeletedOldImage,
    CategoryId? CategoryId = null);