using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Ai.Embedded;
using RookieShop.Infrastructure.Storage.Azurite;

namespace RookieShop.Application.Products.Queries.Search;

public sealed class SearchProductHandler(
    IAiService aiService,
    IReadRepository<Product> repository,
    IAzuriteService azuriteService) : IQueryHandler<SearchProductQuery, PagedResult<IEnumerable<ProductDto>>>
{
    public async Task<PagedResult<IEnumerable<ProductDto>>> Handle(SearchProductQuery request,
        CancellationToken cancellationToken)
    {
        var vector = await aiService.GetEmbeddingAsync(request.Context, cancellationToken);

        ProductsFilterSpec spec = new(vector, request.PageIndex, request.PageSize);

        var products = await repository.ListAsync(spec, cancellationToken);

        products.ForEach(p => p.ImageName = azuriteService.GetFileUrl(p.ImageName));

        var totalRecords = await repository.CountAsync(spec, cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, products.ToProductDto());
    }
}