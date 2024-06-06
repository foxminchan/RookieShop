using Ardalis.Result;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Specifications;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Cache.Redis;

namespace RookieShop.Application.Categories.Queries.List;

public sealed class ListCategoriesHandler(IReadRepository<Category> repository, IRedisService redisService)
    : IQueryHandler<ListCategoriesQuery, PagedResult<IEnumerable<CategoryDto>>>
{
    public async Task<PagedResult<IEnumerable<CategoryDto>>> Handle(ListCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        CategoriesFilterSpec spec = new(request.PageIndex, request.PageSize, request.Search);

        var categories = await redisService.GetOrSetAsync(
            request.CacheKey, 
            () => repository.ListAsync(spec, cancellationToken).Result, 
            request.CacheDuration);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, categories.ToCategoryDto());
    }
}