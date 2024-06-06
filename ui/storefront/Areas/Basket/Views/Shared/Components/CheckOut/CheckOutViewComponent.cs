using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Order.Models;

namespace RookieShop.Storefront.Areas.Basket.Views.Shared.Components.CheckOut;

[ViewComponent]
public sealed class CheckOutViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        OrderFromRequest orderRequest = new ();
        return View(orderRequest);
    }
}