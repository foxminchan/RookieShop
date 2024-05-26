using Ardalis.Result;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Abstractions;

namespace RookieShop.Application.Categories.Queries.List;

public sealed record ListCategoriesQuery(int PageIndex, int PageSize) : IQuery<PagedResult<IEnumerable<CategoryDto>>>, ICachedRequest
{
    public string CacheKey => nameof(Categories);

    public TimeSpan CacheDuration => TimeSpan.FromDays(1);
}