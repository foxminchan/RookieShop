using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Services;

namespace RookieShop.Storefront.Areas.Product.Controllers;

[Area("Product")]
public class ProductController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var query = HttpContext.Request.Query;

        var page = !query.ContainsKey("page") ? 1 : int.Parse(query["page"]!);

        var sortBy = !query.ContainsKey("sortBy") ? null : query["sortBy"].ToString();

        var product = await productService.ListProductsAsync(new()
        {
            PageNumber = page,
            OrderBy = sortBy
        });

        return View(product);
    }

    public async Task<IActionResult> Detail(string id)
    {
        var product = await productService.GetProductByIdAsync(new(id));
        return ModelState.IsValid ? View(product) : BadRequest(ModelState);
    }
}