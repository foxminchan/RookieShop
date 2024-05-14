using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.Get;

public sealed class GetProductHandler(IReadRepository<Product> repository)
    : IQueryHandler<GetProductQuery, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        ProductByIdSpec spec = new(request.Id);

        var product = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        Guard.Against.NotFound(request.Id, product);

        return product.ToProductDto();
    }
}