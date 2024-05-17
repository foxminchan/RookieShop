using RookieShop.Domain.Entities.OrderAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed record DeleteOrderRequest(OrderId Id);