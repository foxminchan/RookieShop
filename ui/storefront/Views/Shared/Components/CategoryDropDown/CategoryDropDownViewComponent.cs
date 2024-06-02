using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Models.Categories;
using RookieShop.Storefront.Areas.Product.Services;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Views.Shared.Components.CategoryDropDown;

[ViewComponent]
public sealed class CategoryDropDownViewComponent(
    ICategoryService categoryService,
    IMemoryCacheService memoryCacheService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var data = await memoryCacheService.GetOrSetAsync(nameof(ListCategoriesViewModel),
            categoryService.ListCategoriesAsync);

        return View(data);
    }
}