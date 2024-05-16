﻿using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator.Events;

public sealed class UpdatedOrderEvent(Order order) : EventBase
{
    public Order Order { get; set; } = order;
}