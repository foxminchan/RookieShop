using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Services;

namespace RookieShop.Storefront.Views.Shared.Components.FeatureProducts;

[ViewComponent]
public sealed class FeatureProductsViewComponent(IReportService reportService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var data = await reportService.GetBestSellerProductsAsync(new());

        return View(data);
    }
}