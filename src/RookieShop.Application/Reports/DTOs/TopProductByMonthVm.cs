using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Reports.DTOs;

public sealed record TopProductByMonthVm(
    ProductId Id,
    string Name,
    int TotalSoldQuantity);