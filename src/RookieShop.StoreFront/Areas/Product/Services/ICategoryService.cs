using Refit;
using RookieShop.Storefront.Areas.Product.Models.Categories;

namespace RookieShop.Storefront.Areas.Product.Services;

public interface ICategoryService
{
    [Get("/categories")]
    Task<ListCategoriesViewModel> ListCategoriesAsync();

    [Get("/categories/{id}")]
    Task<CategoryViewModel> GetCategoryByIdAsync(Guid id);
}