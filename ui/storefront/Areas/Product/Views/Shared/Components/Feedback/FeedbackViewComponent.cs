using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Models.Feedbacks;
using RookieShop.Storefront.Areas.User.Models;

namespace RookieShop.Storefront.Areas.Product.Views.Shared.Components.Feedback;

[ViewComponent]
public sealed class FeedbackViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var productId = Guid.Parse(HttpContext.GetRouteData().Values["id"]?.ToString()!);

        Guid? customerId;

        if (HttpContext.Items["Customer"] is not CustomerViewModel customer)
            customerId = null;
        else
            customerId = customer.Id;

        FeedbackRequest feedback = new()
        {
            ProductId = productId,
            AccountId = customerId
        };

        return View(feedback);
    }
}