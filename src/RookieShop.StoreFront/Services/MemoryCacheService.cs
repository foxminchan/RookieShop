using Ardalis.GuardClauses;
using Microsoft.Extensions.Caching.Memory;

namespace RookieShop.Storefront.Services;

public sealed class MemoryCacheService(IMemoryCache cache) : IMemoryCacheService
{
    private readonly MemoryCacheEntryOptions _cacheDuration = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
    };

    public async Task<T?> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallback)
    {
        Guard.Against.NullOrEmpty(cacheKey);

        if (cache.TryGetValue(cacheKey, out T? cachedItem))
            return cachedItem;

        var item = await getItemCallback();

        if (item is null)
            return item;

        cache.Set(cacheKey, item, _cacheDuration);

        return item;
    }

    public void Remove(string cacheKey)
    {
        Guard.Against.NullOrEmpty(cacheKey);
        cache.Remove(cacheKey);
    }
}