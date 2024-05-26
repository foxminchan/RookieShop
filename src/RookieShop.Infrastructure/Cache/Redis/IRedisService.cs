namespace RookieShop.Infrastructure.Cache.Redis;

public interface IRedisService
{
    Task<T?> GetAsync<T>(string key);

    Task<T> GetOrSetAsync<T>(string key, Func<T> valueFactory);

    Task<T> GetOrSetAsync<T>(string key, Func<T> valueFactory, TimeSpan expiration);

    Task<T> HashGetAsync<T>(string key, string hashKey);

    Task<T> HashSetAsync<T>(string key, string hashKey, T value);

    Task HashRemoveAsync(string key, string hashKey);

    Task RemoveAsync(string key);
}