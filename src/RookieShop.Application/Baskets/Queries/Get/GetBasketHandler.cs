using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Queries.Get;

public sealed class GetBasketHandler(IRedisService redisService) : IQueryHandler<GetBasketQuery, Result<Basket>>
{
    public async Task<Result<Basket>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await redisService.HashGetOrSetAsync<Basket>(
            nameof(Basket),
            request.AccountId.ToString(),
            () => null!);

        Guard.Against.NotFound(request.AccountId, basket);

        return basket;
    }
}