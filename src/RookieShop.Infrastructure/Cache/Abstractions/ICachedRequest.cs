namespace RookieShop.Infrastructure.Cache.Abstractions;

public interface ICachedRequest
{
    string CacheKey { get; }

    TimeSpan CacheDuration { get; }
}