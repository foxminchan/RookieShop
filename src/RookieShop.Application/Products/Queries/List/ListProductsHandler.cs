using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Storage.Azurite;

namespace RookieShop.Application.Products.Queries.List;

public sealed class ListProductsHandler(IReadRepository<Product> repository, IAzuriteService azuriteService)
    : IQueryHandler<ListProductsQuery, PagedResult<IEnumerable<ProductDto>>>
{
    public async Task<PagedResult<IEnumerable<ProductDto>>> Handle(ListProductsQuery request,
        CancellationToken cancellationToken)
    {
        ProductsFilterSpec spec = new(
            request.PageIndex,
            request.PageSize,
            request.OrderBy,
            request.IsDescending,
            request.Search,
            request.CategoryIds);

        var products = await repository.ListAsync(spec, cancellationToken);

        products.ForEach(p => p.ImageName = azuriteService.GetFileUrl(p.ImageName));

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, products.ToProductDto());
    }
}