using RookieShop.Application.Feedbacks.DTOs;

namespace RookieShop.ApiService.ViewModels.Feedbacks;

public static class DtoToViewModelMapper
{
    public static FeedbackVm ToFeedbackVm(this FeedbackDto feedback)
    {
        var customer = feedback.Customer?.ToFeedbackCustomerVm();

        return new(
            feedback.Id,
            feedback.ProductId,
            feedback.Rating,
            feedback.Content,
            feedback.UpdatedDate,
            customer);
    }

    public static List<FeedbackVm> ToFeedbackVm(this IEnumerable<FeedbackDto> feedbacks) =>
        feedbacks.Select(ToFeedbackVm).ToList();

    public static FeedbackCustomerVm ToFeedbackCustomerVm(this FeedbackCustomerDto customer) =>
        new(customer.CustomerId, customer.CustomerName);
}