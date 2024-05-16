using Ardalis.Result;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Command.Delete;

public sealed record DeleteOrderCommand(OrderId Id) : ICommand<Result>;