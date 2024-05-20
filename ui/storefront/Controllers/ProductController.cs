using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Models.Categories;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Controllers;

public class ProductController(ICategoryService categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.ListCategoriesAsync();
        return View(categories);
    }
}