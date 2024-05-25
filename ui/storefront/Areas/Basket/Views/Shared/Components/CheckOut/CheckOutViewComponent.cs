using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.Basket.Views.Shared.Components.CheckOut;

[ViewComponent]
public sealed class CheckOutViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}