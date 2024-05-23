using Microsoft.AspNetCore.Mvc;

namespace RookieShop.Storefront.Areas.Product.Views.Shared.Components.Rating;

[ViewComponent]
public sealed class RatingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}