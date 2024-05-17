using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed record ListOrdersRequest(int PageIndex, int PageSize, OrderStatus? Status, CustomerId? UserId);