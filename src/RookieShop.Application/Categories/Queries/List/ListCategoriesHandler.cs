using Ardalis.Result;
using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Categories.Queries.List;

public sealed class ListCategoriesHandler(IReadRepository<Category> repository)
    : IQueryHandler<ListCategoriesQuery, PagedResult<IEnumerable<CategoryDto>>>
{
    public async Task<PagedResult<IEnumerable<CategoryDto>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {
        CategoriesFilterSpec spec = new(request.PageIndex, request.PageSize);

        var categories = await repository.ListAsync(spec, cancellationToken);

        var totalRecord = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecord / (double)request.PageSize);

        var pagedInfo = new PagedInfo(request.PageIndex, request.PageSize, totalRecord, totalPages);

        return new(pagedInfo, categories.ToCategoryDto());
    }
}