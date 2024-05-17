using RookieShop.Domain.Entities.OrderAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed record GetOrderRequest(OrderId Id);