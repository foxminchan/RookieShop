using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class UpdateOrderRequest
{
    public OrderId Id { get; set; }
    public OrderStatus OrderStatus { get; set; }
}