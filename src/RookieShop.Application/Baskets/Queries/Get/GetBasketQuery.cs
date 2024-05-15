using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Queries.Get;

public sealed record GetBasketQuery(Guid AccountId) : IQuery<Result<Basket>>;