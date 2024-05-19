using System.Text;
using System.Text.Json;
using Ardalis.GuardClauses;
using RookieShop.Infrastructure.Cache.Redis.Settings;
using StackExchange.Redis;

namespace RookieShop.Infrastructure.Cache.Redis.Internal;

public sealed class RedisService(RedisSettings redisSettings) : IRedisService
{
    private const string GetKeysLuaScript = """
                                                local pattern = ARGV[1]
                                                local keys = redis.call('KEYS', pattern)
                                                return keys
                                            """;

    private const string ClearCacheLuaScript = """
                                                   local pattern = ARGV[1]
                                                   for _,k in ipairs(redis.call('KEYS', pattern)) do
                                                       redis.call('DEL', k)
                                                   end
                                               """;

    private readonly SemaphoreSlim _connectionLock = new(1, 1);

    private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer = new(
        () => ConnectionMultiplexer.Connect(redisSettings.GetConnectionString())
    );

    private ConnectionMultiplexer ConnectionMultiplexer => _connectionMultiplexer.Value;

    private IDatabase Database
    {
        get
        {
            _connectionLock.Wait();

            try
            {
                return ConnectionMultiplexer.GetDatabase();
            }
            finally
            {
                _connectionLock.Release();
            }
        }
    }

    public async Task<T> GetOrSetAsync<T>(string key, Func<T> valueFactory)
        => await GetOrSetAsync($"{redisSettings.Prefix}:{key}", valueFactory,
            TimeSpan.FromSeconds(redisSettings.RedisDefaultSlidingExpirationInSecond));

    public async Task<T> GetOrSetAsync<T>(string key, Func<T> valueFactory, TimeSpan expiration)
    {
        Guard.Against.NullOrEmpty(key);

        var keyWithPrefix = $"{redisSettings.Prefix}:{key}";

        var cachedValue = await Database.StringGetAsync(keyWithPrefix);
        if (!string.IsNullOrEmpty(cachedValue)) return GetByteToObject<T>(cachedValue);

        var newValue = valueFactory();
        if (newValue is not null)
            await Database.StringSetAsync(keyWithPrefix, JsonSerializer.Serialize(newValue), expiration);

        return newValue;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        Guard.Against.NullOrEmpty(redisSettings.Prefix);

        var keyWithPrefix = $"{redisSettings.Prefix}:{key}";

        var cachedValue = await Database.StringGetAsync(keyWithPrefix);
        return !string.IsNullOrEmpty(cachedValue)
            ? GetByteToObject<T>(cachedValue)
            : default;
    }

    public async Task<T> HashGetOrSetAsync<T>(string key, string hashKey, Func<T> valueFactory)
    {
        Guard.Against.NullOrEmpty(key);
        Guard.Against.NullOrEmpty(hashKey);

        var keyWithPrefix = $"{redisSettings.Prefix}:{key}";
        var value = await Database.HashGetAsync(keyWithPrefix, hashKey.ToLower());

        if (!string.IsNullOrEmpty(value)) return GetByteToObject<T>(value);

        if (valueFactory() is not null)
            await Database.HashSetAsync(keyWithPrefix, hashKey.ToLower(),
                JsonSerializer.Serialize(valueFactory()));

        return valueFactory();
    }

    public async Task<IEnumerable<string>> GetKeysAsync(string pattern)
    {
        var keys = await Database.ScriptEvaluateAsync(GetKeysLuaScript, values: [pattern]);

        return ((RedisResult[])keys!)
            .Where(x => x.ToString().StartsWith(redisSettings.Prefix))
            .Select(x => x.ToString())
            .ToArray();
    }

    public async Task<IEnumerable<T>> GetValuesAsync<T>(string key)
    {
        var values = await Database.HashGetAllAsync($"{redisSettings.Prefix}:{key}");
        return values.Select(x => GetByteToObject<T>(x.Value)).ToArray();
    }

    public async Task<bool> RemoveAllKeysAsync(string pattern = "*")
    {
        var succeed = true;

        var keys = await GetKeysAsync($"{redisSettings.Prefix}:{pattern}");
        foreach (var key in keys) succeed = await Database.KeyDeleteAsync(key);

        return succeed;
    }

    public async Task HashRemoveAsync(string key, string hashKey)
        => await Database.HashDeleteAsync($"{redisSettings.Prefix}:{key}", hashKey.ToLower());

    public async Task RemoveAsync(string key) => await Database.KeyDeleteAsync($"{redisSettings.Prefix}:{key}");

    public async Task ResetAsync()
        => await Database.ScriptEvaluateAsync(
            ClearCacheLuaScript,
            values: [redisSettings.Prefix + "*"],
            flags: CommandFlags.FireAndForget);

    private static T GetByteToObject<T>(RedisValue value)
    {
        var result = JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(value!));
        return result is null ? throw new InvalidOperationException("Deserialization failed.") : result;
    }
}