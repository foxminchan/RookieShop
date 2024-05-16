using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.ProductAggregator;

namespace RookieShop.Application.Products.DTOs;

public static class DomainToDtoMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        var imageUrl = string.Concat(UriComposer.BaseAzUrl, product.ImageName);

        var category = product.Category?.ToCategoryDto();

        var feedbacks = product.Feedbacks?.ToProductFeedbackDto();

        return new(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price.Price,
            product.Price.PriceSale,
            imageUrl,
            category,
            product.GetAverageRating(),
            product.GetTotalFeedback(),
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