using RookieShop.Storefront.Areas.Product.Models.Categories;
using RookieShop.Storefront.Areas.Product.Models.Products;

namespace RookieShop.Storefront.Areas.Product.Models;

public sealed class ProductCategoryViewModel
{
    public ListProductsViewModel Products { get; set; } = new();
    public ListCategoriesViewModel Categories { get; set; } = new();
}