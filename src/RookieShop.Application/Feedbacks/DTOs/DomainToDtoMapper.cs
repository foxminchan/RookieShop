using RookieShop.Domain.Entities.FeedbackAggregator;

namespace RookieShop.Application.Feedbacks.DTOs;

public static class DomainToDtoMapper
{
    public static FeedbackDto ToFeedbackDto(this Feedback feedback) =>
        new(feedback.Id, feedback.ProductId, feedback.Rating, feedback.Content, feedback.CustomerId);

    public static IEnumerable<FeedbackDto> ToFeedbackDto(this IEnumerable<Feedback> feedbacks) =>
        feedbacks.Select(ToFeedbackDto);
}