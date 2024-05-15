using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Command.Update;

public sealed class UpdateBasketHandler(IRedisService redisService, ILogger<UpdateBasketHandler> logger)
    : ICommandHandler<UpdateBasketCommand, Result<Basket>>
{
    public async Task<Result<Basket>> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await redisService.GetAsync<Basket>(request.AccountId.ToString());

        Guard.Against.NotFound(request.AccountId, basket);

        foreach (var basketDetail in request.BasketDetails)
        {
            basket.UpdateBasketDetails(basketDetail);
        }

        logger.LogInformation("[{Command}] - Updating basket for account {AccountId} with {@Basket} details",
            nameof(UpdateBasketCommand), request.AccountId, JsonSerializer.Serialize(request.BasketDetails));

        var result = await redisService.HashGetOrSetAsync(
            nameof(Basket),
            basket.AccountId.ToString(),
            () => basket);

        return result;
    }
}