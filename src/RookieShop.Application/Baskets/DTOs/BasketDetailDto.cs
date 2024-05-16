using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Baskets.DTOs;

public sealed record BasketDetailDto(
    ProductId Id,
    int Quantity,
    decimal Price);