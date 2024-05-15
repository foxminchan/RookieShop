using RookieShop.Application.Feedbacks.DTOs;

namespace RookieShop.ApiService.ViewModels.Feedbacks;

public static class DtoToViewModelMapper
{
    public static FeedbackVm ToFeedbackVm(this FeedbackDto feedback) =>
        new(feedback.Id,
            feedback.ProductId,
            feedback.Rating,
            feedback.Content,
            feedback.CustomerId);

    public static List<FeedbackVm> ToFeedbackVm(this IEnumerable<FeedbackDto> feedbacks) =>
        feedbacks.Select(ToFeedbackVm).ToList();
}