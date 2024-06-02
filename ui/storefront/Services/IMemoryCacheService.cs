namespace RookieShop.Storefront.Services;

public interface IMemoryCacheService
{
    public Task<T?> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> getItemCallback);
    public void Remove(string cacheKey);
}