using System.Text.Json;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Command.Create;

public sealed class CreateBasketHandler(IRedisService redisService, ILogger<CreateBasketHandler> logger)
    : ICommandHandler<CreateBasketCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = Basket.Factory.Create(request.AccountId, request.ProductId, request.Quantity, request.Price);

        logger.LogInformation("[{Command}] - Creating basket for account {AccountId} with {@Basket}",
            nameof(CreateBasketCommand), request.AccountId, JsonSerializer.Serialize(basket));

        var existingBasket = await redisService.HashGetAsync<Basket?>(nameof(Basket), request.AccountId.ToString());

        if (existingBasket is not null)
        {
            basket = existingBasket.MergeBasket(basket);
            await redisService.HashSetAsync(nameof(Basket), request.AccountId.ToString(), basket);
        }
        else
        {
            basket = await redisService.HashSetAsync(nameof(Basket), basket.AccountId.ToString(), basket);
        }

        return basket.AccountId;
    }
}