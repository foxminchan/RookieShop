using Refit;
using RookieShop.Storefront.Areas.Product.Models.Feedbacks;
using RookieShop.Storefront.Constants;

namespace RookieShop.Storefront.Areas.Product.Services;

public interface IFeedbackService
{
    [Get("/feedbacks")]
    Task<ListFeedbackViewModel> ListFeedbacksAsync([Query] FeedbackFilterParams filterParams);

    [Post("/feedbacks")]
    Task CreateFeedbackAsync(FeedbackRequest feedbackRequest, [Header(HeaderName.IdempotencyKey)] Guid requestId);
}