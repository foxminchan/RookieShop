using RookieShop.ApiService.ViewModels.Feedbacks;
using RookieShop.Application.Products.DTOs;

namespace RookieShop.ApiService.ViewModels.Products;

public static class DtoToViewModelMapper
{
    public static ProductVm ToProductVm(this ProductDto product)
    {
        var feedbacks = product.Feedbacks?.ToProductFeedbackVm();

        return new(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price,
            product.PriceSale,
            product.ImageUrl,
            product.Category,
            feedbacks);
    }

    public static List<ProductVm> ToProductVm(this IEnumerable<ProductDto> products) =>
        products.Select(ToProductVm).ToList();

    public static ProductFeedbackVm ToProductFeedbackVm(this ProductFeedbackDto feedback) =>
        new(feedback.Id,
            feedback.Rating,
            feedback.Content,
            feedback.CustomerId);

    public static List<ProductFeedbackVm> ToProductFeedbackVm(this IEnumerable<ProductFeedbackDto> feedbacks) =>
        feedbacks.Select(ToProductFeedbackVm).ToList();
}