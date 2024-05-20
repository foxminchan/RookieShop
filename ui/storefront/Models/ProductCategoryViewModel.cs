using RookieShop.Storefront.Models.Categories;
using RookieShop.Storefront.Models.Products;

namespace RookieShop.Storefront.Models;

public sealed class ProductCategoryViewModel
{
    public ListProductsViewModel Products { get; set; } = new();
    public ListCategoriesViewModel Categories { get; set; } = new();
}