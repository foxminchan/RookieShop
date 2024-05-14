using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.GetByCategory;

public sealed class GetByCategoryHandler(IReadRepository<Product> repository)
    : IQueryHandler<GetByCategoryQuery, PagedResult<IEnumerable<ProductDto>>>
{
    public async Task<PagedResult<IEnumerable<ProductDto>>> Handle(GetByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        ProductsFilterSpec spec = new(
            request.PageIndex,
            request.PageSize,
            request.CategoryId,
            request.OrderBy,
            request.IsDescending);

        var products = await repository.ListAsync(spec, cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, products.ToProductDto());
    }
}