using MediatR;
using RookieShop.Domain.Entities.CategoryAggregator.Events;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Categories.Events;

public sealed class CachedCategoryInvalidationHandler(IRedisService redisService) :
    INotificationHandler<CreatedCategoryEvent>,
    INotificationHandler<UpdatedCategoryEvent>,
    INotificationHandler<DeletedCategoryEvent>
{
    private const string CacheKey = nameof(Categories);

    public async Task Handle(CreatedCategoryEvent notification, CancellationToken cancellationToken) =>
        await InvalidateCache();

    public async Task Handle(UpdatedCategoryEvent notification, CancellationToken cancellationToken) =>
        await InvalidateCache();

    public async Task Handle(DeletedCategoryEvent notification, CancellationToken cancellationToken) =>
        await InvalidateCache();

    private async Task InvalidateCache() => await redisService.RemoveAsync(CacheKey);
}