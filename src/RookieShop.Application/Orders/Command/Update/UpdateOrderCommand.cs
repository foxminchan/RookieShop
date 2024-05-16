using Ardalis.Result;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Command.Update;

public sealed record UpdateOrderCommand(OrderId Id, OrderStatus OrderStatus) : ICommand<Result<OrderDto>>;