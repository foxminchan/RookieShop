namespace RookieShop.Infrastructure.Cache.Redis;

public interface IRedisService
{
    Task<T?> GetAsync<T>(string key);

    Task<T> GetOrSetAsync<T>(string key, Func<T> valueFactory);

    Task<T> GetOrSetAsync<T>(string key, Func<T> valueFactory, TimeSpan expiration);

    Task<T> HashGetOrSetAsync<T>(string key, string hashKey, Func<T> valueFactory);

    Task<IEnumerable<string>>? GetKeysAsync(string pattern);

    Task<IEnumerable<T>> GetValuesAsync<T>(string key);

    Task<bool> RemoveAllKeysAsync(string pattern = "*");

    Task HashRemoveAsync(string key, string hashKey);

    Task RemoveAsync(string key);

    Task ResetAsync();
}