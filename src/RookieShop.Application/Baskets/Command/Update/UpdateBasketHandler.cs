using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Command.Update;

public sealed class UpdateBasketHandler(IRedisService redisService)
    : ICommandHandler<UpdateBasketCommand, Result<Basket>>
{
    public async Task<Result<Basket>> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await redisService.GetAsync<Basket>(request.AccountId);

        Guard.Against.NotFound(request.AccountId, basket);

        foreach (var basketDetail in request.BasketDetails)
        {
            basket.UpdateBasketDetails(basketDetail);
        }

        await redisService.GetOrSetAsync(basket.AccountId, () => basket, TimeSpan.FromDays(30));

        return basket;
    }
}