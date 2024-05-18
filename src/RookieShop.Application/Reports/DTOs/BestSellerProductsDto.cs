namespace RookieShop.Application.Reports.DTOs;

public sealed record BestSellerProductsDto(
    Guid ProductId,
    string ProductName,
    int TotalSoldQuantity,
    decimal Price,
    decimal PriceSale,
    string? ImageUrl);