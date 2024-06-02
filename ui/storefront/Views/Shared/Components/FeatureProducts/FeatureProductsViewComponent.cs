using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Models.Products;
using RookieShop.Storefront.Models.Report;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Views.Shared.Components.FeatureProducts;

[ViewComponent]
public sealed class FeatureProductsViewComponent(IReportService reportService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var data = await reportService.GetBestSellerProductsAsync(new());

        var result = data.Select(x => new BestSellerProductViewModel
        {
            ProductId = x.ProductId,
            ProductName = x.ProductName,
            TotalSoldQuantity = x.TotalSoldQuantity,
            Price = JsonSerializer.Deserialize<ProductPrice>(x.Price),
            ImageUrl = x.ImageUrl
        }).ToList();

        return View(result);
    }
}