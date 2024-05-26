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

        var result = await redisService.HashGetOrSetAsync(
            nameof(Basket),
            basket.AccountId.ToString(),
            () => basket);

        return result.AccountId;
    }
}