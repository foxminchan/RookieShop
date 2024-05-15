﻿using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Command.Update;

public sealed record UpdateBasketCommand(Guid AccountId, List<BasketDetail> BasketDetails) : ICommand<Result<Basket>>;