using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Orders;

public sealed record OrderVm(
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
    List<OrderItemVm> Items);