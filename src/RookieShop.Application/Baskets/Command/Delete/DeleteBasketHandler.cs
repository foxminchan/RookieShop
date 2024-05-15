using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Command.Delete;

public sealed class DeleteBasketHandler(IRedisService redisService) : ICommandHandler<DeleteBasketCommand, Result>
{
    public async Task<Result> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await redisService.GetAsync<Basket>(request.AccountId);

        Guard.Against.NotFound(request.AccountId, basket);

        await redisService.HashRemoveAsync(nameof(Basket), basket.AccountId);

        return Result.Success();
    }
}