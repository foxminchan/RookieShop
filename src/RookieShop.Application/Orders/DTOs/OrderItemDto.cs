using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Orders.DTOs;

public sealed record OrderItemDto(ProductId Id, int Quantity, decimal Price);