using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;

namespace RookieShop.Application.Orders.DTOs;

public sealed record OrderDto(
    OrderId Id,
    PaymentMethod PaymentMethod,
    string? Last4,
    string? Brand,
    string? ChargeId,
    string? Street,
    string? City,
    string? Province,
    decimal TotalPrice,
    CustomerId CustomerId,
    OrderStatus OrderStatus,
    IEnumerable<OrderItemsDto> OrderItems);