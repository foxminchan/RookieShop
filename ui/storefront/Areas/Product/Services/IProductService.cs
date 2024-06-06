using Refit;
using RookieShop.Storefront.Areas.Product.Models.Products;
using RookieShop.Storefront.Constants;

namespace RookieShop.Storefront.Areas.Product.Services;

public interface IProductService
{
    [Get("/products")]
    Task<ListProductsViewModel> ListProductsAsync([Query] ProductFilterParams filterParams);

    [Get("/products/{id}")]
    Task<ProductViewModel> GetProductByIdAsync(Guid id);

    [Post("/products/check-stock")]
    Task<CheckStockResponse> CheckStockAsync(CheckStockRequest request, [Header(HeaderName.IdempotencyKey)] Guid requestId);
}