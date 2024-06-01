using Ardalis.Result;
using RookieShop.Application.Baskets.DTOs;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Queries.List;

public sealed class ListBasketsHandler(IRedisService redisService)
    : IQueryHandler<ListBasketsQuery, Result<IEnumerable<BasketDto>>>
{
    public async Task<Result<IEnumerable<BasketDto>>> Handle(ListBasketsQuery request,
        CancellationToken cancellationToken)
    {
        var baskets = await redisService.HashGetAllAsync<Basket>(nameof(Basket));

        return baskets.ToBasketDto().ToList();
    }
}