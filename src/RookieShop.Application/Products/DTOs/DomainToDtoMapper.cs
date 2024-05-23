using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.ProductAggregator;

namespace RookieShop.Application.Products.DTOs;

public static class DomainToDtoMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        var category = product.Category?.ToCategoryDto();

        var feedbacks = product.Feedbacks?.ToProductFeedbackDto();

        return new(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price.Price,
            product.Price.PriceSale,
            product.ImageName,
            category,
            feedbacks);
    }

    public static IEnumerable<ProductDto> ToProductDto(this IEnumerable<Product> products) =>
        products.Select(ToProductDto);

    public static ProductFeedbackDto ToProductFeedbackDto(this Feedback feedback) =>
        new(feedback.Id,
            feedback.Rating,
            feedback.Content,
            feedback.CustomerId);

    public static IEnumerable<ProductFeedbackDto> ToProductFeedbackDto(this IEnumerable<Feedback> feedbacks) =>
        feedbacks.Select(ToProductFeedbackDto);
}