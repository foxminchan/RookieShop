using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Baskets.Commands.DeleteItem;

public sealed class DeleteItemHandler(IRedisService redisService) : ICommandHandler<DeleteItemCommand, Result>
{
    public async Task<Result> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var basket = await redisService.HashGetAsync<Basket>(nameof(Basket), request.AccountId.ToString());

        Guard.Against.NotFound(request.AccountId, basket);

        if (basket.BasketDetails.Count == 1)
        {
            await redisService.HashRemoveAsync(nameof(Basket), request.AccountId.ToString());
            return Result.Success();
        }

        var basketDetail = basket.BasketDetails.First(x => x.Id == request.ProductId);

        basketDetail.Quantity = 0;

        basket.UpdateBasketDetails(basketDetail);

        await redisService.HashSetAsync(nameof(Basket), request.AccountId.ToString(), basket);

        return Result.Success();
    }
}