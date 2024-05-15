using RookieShop.Application.Categories.DTOs;
using RookieShop.Application.Feedbacks.DTOs;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.ProductAggregator;

namespace RookieShop.Application.Products.DTOs;

public static class DomainToDtoMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        var imageUrl = string.Concat(UriComposer.BaseAzUrl, product.ImageName);

        var category = product.Category?.ToCategoryDto();

        var feedbacks = product.Feedbacks?.ToFeedbackDto();

        return new(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price.Price,
            product.Price.PriceSale,
            imageUrl,
            category,
            feedbacks);
    }

    public static IEnumerable<ProductDto> ToProductDto(this IEnumerable<Product> products) =>
        products.Select(ToProductDto);
}