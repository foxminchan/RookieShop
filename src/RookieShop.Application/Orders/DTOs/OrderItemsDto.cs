using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Application.Orders.DTOs;

public sealed record OrderItemsDto(ProductId Id, int Quantity, decimal Price);