using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator;

namespace RookieShop.Application.Feedbacks.DTOs;

public static class DomainToDtoMapper
{
    public static FeedbackDto ToFeedbackDto(this Feedback feedback)
    {
        var customer = feedback.Customer?.ToFeedbackCustomerDto();

        return new(feedback.Id, feedback.ProductId, feedback.Rating, feedback.Content, feedback.UpdateDate, customer);
    }

    public static IEnumerable<FeedbackDto> ToFeedbackDto(this IEnumerable<Feedback> feedbacks) =>
        feedbacks.Select(ToFeedbackDto);

    public static FeedbackCustomerDto ToFeedbackCustomerDto(this Customer customer) =>
        new(customer.Id, customer.Name);
}