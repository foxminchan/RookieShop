namespace RookieShop.Infrastructure.Cache.Redis;

public interface IRedisService
{
    Task<T?> Get<T>(string key);

    Task<T> GetOrSet<T>(string key, Func<T> valueFactory);

    Task<T> GetOrSet<T>(string key, Func<T> valueFactory, TimeSpan expiration);

    Task<T> HashGetOrSet<T>(string key, string hashKey, Func<T> valueFactory);

    Task<IEnumerable<string>>? GetKeys(string pattern);

    Task<IEnumerable<T>> GetValues<T>(string key);

    Task<bool> RemoveAllKeys(string pattern = "*");

    Task Remove(string key);

    Task Reset();
}