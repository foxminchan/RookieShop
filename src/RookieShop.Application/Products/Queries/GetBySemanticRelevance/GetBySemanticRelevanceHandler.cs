using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.GenAi.OpenAi;

namespace RookieShop.Application.Products.Queries.GetBySemanticRelevance;

public sealed class GetBySemanticRelevanceHandler(IReadRepository<Product> repository, IOpenAiService aiService)
    : IQueryHandler<GetBySemanticRelevanceQuery, PagedResult<IEnumerable<ProductDto>>>
{
    public async Task<PagedResult<IEnumerable<ProductDto>>> Handle(GetBySemanticRelevanceQuery request,
        CancellationToken cancellationToken)
    {
        var vector = await aiService.GetEmbeddingAsync(request.Text, cancellationToken);

        ProductsFilterSpec spec = new(request.PageIndex, request.PageSize, vector);

        var products = await repository.ListAsync(spec, cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, products.ToProductDto());
    }
}