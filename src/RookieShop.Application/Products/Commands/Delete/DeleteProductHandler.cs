using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Commands.Delete;

public sealed class DeleteProductHandler(IRepository<Product> repository)
    : ICommandHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, product);

        product.Delete();

        await repository.UpdateAsync(product, cancellationToken);

        return Result.Success();
    }
}