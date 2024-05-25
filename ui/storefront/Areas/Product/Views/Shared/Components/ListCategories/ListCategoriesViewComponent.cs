using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Services;

namespace RookieShop.Storefront.Areas.Product.Views.Shared.Components.ListCategories;

[ViewComponent]
public class ListCategoriesViewComponent(ICategoryService categoryService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await categoryService.ListCategoriesAsync();
        return View(categories);
    }
}