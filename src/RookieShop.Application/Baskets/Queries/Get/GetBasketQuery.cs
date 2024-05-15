using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Baskets.Queries.Get;

public sealed record GetBasketQuery(string AccountId) : IQuery<Result<Basket>>;