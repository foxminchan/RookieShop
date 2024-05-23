using Microsoft.AspNetCore.Mvc;
using RookieShop.Storefront.Areas.Product.Services;

namespace RookieShop.Storefront.Areas.Product.Views.Shared.Components.Rating;

[ViewComponent]
public sealed class RatingViewComponent(IFeedbackService feedbackService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(IQueryCollection query, Guid productId)
    {
        var page = !query.ContainsKey("page") ? 1 : int.Parse(query["page"]!);

        var feedback = await feedbackService.ListFeedbacksAsync(new()
        {
            PageNumber = page,
            ProductId = productId
        });

        return View(feedback);
    }
}