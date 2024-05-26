﻿using Ardalis.Result;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Command.DeleteItem;

public sealed record DeleteItemCommand(Guid AccountId, ProductId ProductId) : ICommand<Result>;