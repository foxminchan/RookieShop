using Ardalis.GuardClauses;
using FluentValidation;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Products.Services;

public sealed class ProductService(IRepository<Product> repository) : IProductService
{
    public async Task StockValidationAsync(List<OrderDetail> orderDetails, CancellationToken cancellationToken)
    {
        foreach (var orderDetail in orderDetails)
        {
            var product = await repository.GetByIdAsync(orderDetail.ProductId, cancellationToken);

            Guard.Against.NotFound(orderDetail.ProductId, product);

            if (product.Quantity < orderDetail.Quantity)
                throw new ValidationException(
                    $"Product {product.Name} has only {product.Quantity} left in stock.");

            product.RemoveStock(orderDetail.Quantity);

            await repository.UpdateAsync(product, cancellationToken);
        }
    }
}