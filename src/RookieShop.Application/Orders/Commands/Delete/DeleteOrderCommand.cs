﻿using Ardalis.Result;
using RookieShop.Domain.Entities.OrderAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Orders.Commands.Delete;

public sealed record DeleteOrderCommand(OrderId Id) : ICommand<Result>;