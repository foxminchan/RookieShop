using Refit;
using RookieShop.Storefront.Models.Feedbacks;

namespace RookieShop.Storefront.Services;

public interface IFeedbackService
{
    [Get("/feedbacks")]
    Task<ListFeedbackViewModel> GetFeedbacksAsync([Query] FeedbackFilterParams filterParams);
}