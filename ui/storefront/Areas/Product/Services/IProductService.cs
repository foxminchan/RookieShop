using Refit;
using RookieShop.Storefront.Areas.Product.Models.Products;

namespace RookieShop.Storefront.Areas.Product.Services;

public interface IProductService
{
    [Get("/products")]
    Task<ListProductsViewModel> ListProductsAsync([Query] ProductFilterParams filterParams);

    [Get("/products/{id}")]
    Task<ProductViewModel> GetProductByIdAsync(Guid id);
}