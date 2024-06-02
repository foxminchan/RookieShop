using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

namespace RookieShop.ApiService.ViewModels.Reports;

public sealed record BestSellerProductsVm(
    Guid ProductId,
    string? ProductName,
    int TotalSoldQuantity,
    ProductPrice? Price,
    string? ImageUrl
);