using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Application.Products.DTOs;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Specifications;
using RookieShop.Domain.SharedKernel;
using RookieShop.Infrastructure.Storage.Azurite;

namespace RookieShop.Application.Products.Queries.Get;

public sealed class GetProductHandler(IReadRepository<Product> repository, IAzuriteService azuriteService)
    : IQueryHandler<GetProductQuery, Result<ProductDto>>
{
    public async Task<Result<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        ProductByIdSpec spec = new(request.Id);

        var product = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        Guard.Against.NotFound(request.Id, product);

        product.ImageName = azuriteService.GetFileUrl(product.ImageName);

        return product.ToProductDto();
    }
}