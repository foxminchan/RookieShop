using Ardalis.Result;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Queries.List;

public sealed record ListOrdersQuery(
    int PageIndex,
    int PageSize,
    OrderStatus? Status,
    CustomerId? UserId, 
    string? Search = null) : IQuery<PagedResult<IEnumerable<OrderDto>>>;