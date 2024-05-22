using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Services;

namespace RookieShop.Storefront.Areas.Product.Controllers;

[Area("Product")]
public class ProductController(
    ICategoryService categoryService,
    IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.ListCategoriesAsync();
        return View(categories);
    }

    public async Task<IActionResult> Detail(string id)
    {
        var product = await productService.GetProductByIdAsync(new(id));
        return ModelState.IsValid ? View(product) : BadRequest(ModelState);
    }
}