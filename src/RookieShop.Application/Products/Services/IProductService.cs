using RookieShop.Domain.Entities.OrderAggregator;

namespace RookieShop.Application.Products.Services;

public interface IProductService
{
    Task StockValidationAsync(List<OrderDetail> orderDetails, CancellationToken cancellationToken);
}