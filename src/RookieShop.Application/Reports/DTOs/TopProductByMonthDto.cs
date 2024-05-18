using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Reports.DTOs;

public sealed record TopProductByMonthDto(
    ProductId Id,
    string Name,
    int TotalSoldQuantity);