using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.ProductAggregator;

namespace RookieShop.Application.Products.DTOs;

public static class DomainToDtoMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        var imageUrl = string.Concat(UriComposer.BaseAzUrl, product.ImageName);

        var category = product.Category?.ToCategoryDto();

        return new(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price.Price,
            product.Price.PriceSale,
            imageUrl,
            category);
    }

    public static IEnumerable<ProductDto> ToProductDto(this IEnumerable<Product> products) =>
        products.Select(ToProductDto);
}