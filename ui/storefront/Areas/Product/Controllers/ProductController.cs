using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Models.Products;
using RookieShop.Storefront.Areas.Product.Services;

namespace RookieShop.Storefront.Areas.Product.Controllers;

[Area("Product")]
public class ProductController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var query = HttpContext.Request.Query;

        var page = !query.ContainsKey("page") ? 1 : int.Parse(query["page"]!);

        var sort = !query.ContainsKey("sort") ? nameof(ProductViewModel.Id) : query["sort"].ToString();

        var order = !query.ContainsKey("order") || bool.Parse(query["order"]!);

        var category = !query.ContainsKey("category") ? null :
            query["category"]
                .Select(c => Guid.TryParse(c, out var parsedGuid) ? parsedGuid : Guid.Empty)
                .ToArray();

        var product = await productService.ListProductsAsync(new()
        {
            PageNumber = page,
            OrderBy = sort,
            IsDescending = order,
            CategoryIds = category
        });

        return View(product);
    }

    public async Task<IActionResult> Detail(string id)
    {
        var product = await productService.GetProductByIdAsync(new(id));
        return ModelState.IsValid ? View(product) : BadRequest(ModelState);
    }
}