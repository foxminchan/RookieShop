using Refit;
using RookieShop.Storefront.Areas.Product.Models.Feedbacks;

namespace RookieShop.Storefront.Areas.Product.Services;

public interface IFeedbackService
{
    [Get("/feedbacks")]
    Task<ListFeedbackViewModel> ListFeedbacksAsync([Query] FeedbackFilterParams filterParams);
}