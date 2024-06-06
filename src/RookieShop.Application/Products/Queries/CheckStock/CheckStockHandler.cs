using Ardalis.Result;
using MediatR;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Queries.CheckStock;

public sealed class CheckStockHandler(IReadRepository<Product> repository)
    : IRequestHandler<CheckStockQuery, Result<bool>>
{
    public async Task<Result<bool>> Handle(CheckStockQuery request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Requests)
        {
            var product = await repository.GetByIdAsync(item.Id, cancellationToken);

            if (product is null)
                return false;

            if (product.Quantity < item.Quantity)
                return false;
        }

        return true;
    }
}