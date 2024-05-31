using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

namespace RookieShop.Application.Reports.DTOs;

public sealed record BestSellerProductsDto(
    Guid ProductId,
    string ProductName,
    int TotalSoldQuantity,
    ProductPrice Price,
    string? ImageUrl);