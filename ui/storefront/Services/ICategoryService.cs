using Refit;
using RookieShop.Storefront.Models.Categories;

namespace RookieShop.Storefront.Services;

public interface ICategoryService
{
    [Get("/categories")]
    Task<ListCategoriesViewModel> ListCategoriesAsync();

    [Get("/categories/{id}")]
    Task<CategoryViewModel> GetCategoryByIdAsync(Guid id);
}