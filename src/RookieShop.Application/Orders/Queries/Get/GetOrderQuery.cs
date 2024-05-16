using Ardalis.Result;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Queries.Get;

public sealed record GetOrderQuery(OrderId OrderId) : IQuery<Result<OrderDto>>;