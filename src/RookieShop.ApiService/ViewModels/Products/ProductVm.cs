using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.ProductAggregator.Enums;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Products;

public sealed record ProductVm(
    ProductId Id,
    string Name,
    string? Description,
    int Quantity,
    decimal Price,
    decimal PriceSale,
    string? ImageUrl,
    double AverageRating,
    int TotalReviews,
    ProductStatus Status,
    DateTime CreatedDate,
    DateTime? UpdatedDate,
    CategoryDto? Category);