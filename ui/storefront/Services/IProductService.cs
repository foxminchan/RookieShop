using Refit;
using RookieShop.Storefront.Models.Products;

namespace RookieShop.Storefront.Services;

public interface IProductService
{
    [Get("/products")]
    Task<ListProductsViewModel> ListProductsAsync([Query] ProductFilterParams filterParams);

    [Get("/products/{id}")]
    Task<ProductViewModel> GetProductByIdAsync(Guid id);
}