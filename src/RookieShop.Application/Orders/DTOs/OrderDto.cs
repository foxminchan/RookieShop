using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;

namespace RookieShop.Application.Orders.DTOs;

public sealed record OrderDto(
    PaymentMethod PaymentMethod,
    string? Last4,
    string? Brand,
    string? ChargeId,
    string? Street,
    string? City,
    string? Province,
    CustomerId CustomerId,
    OrderStatus OrderStatus,
    IEnumerable<OrderItemsDto> OrderItems);