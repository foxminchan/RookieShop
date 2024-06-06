using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Baskets.DTOs;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Commands.Update;

public sealed class UpdateBasketHandler(IRedisService redisService, ILogger<UpdateBasketHandler> logger)
    : ICommandHandler<UpdateBasketCommand, Result<BasketDto>>
{
    public async Task<Result<BasketDto>> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await redisService.HashGetAsync<Basket>(nameof(Basket), request.AccountId.ToString());

        Guard.Against.NotFound(request.AccountId, basket);

        var basketDetail = basket.BasketDetails.First(x => x.Id == request.ProductId);

        basketDetail.Quantity = request.Quantity;

        logger.LogInformation("[{Command}] - Updating basket for account {AccountId} with {@Basket}",
            nameof(UpdateBasketCommand), request.AccountId, JsonSerializer.Serialize(basket));

        var result = await redisService.HashSetAsync(nameof(Basket), request.AccountId.ToString(), basket);

        return result.ToBasketDto();
    }
}