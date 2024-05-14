using RookieShop.Application.Categories.DTOs;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

namespace RookieShop.Application.Products.DTOs;

public static class DomainToDtoMapper
{
    public static ProductDto ToProductDto(this Product product)
    {
        var productImages = product.ProductImages?.ToProductImageDto();

        var category = product.Category?.ToCategoryDto();

        return new(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price.Price,
            product.Price.PriceSale,
            productImages,
            category);
    }

    public static IEnumerable<ProductDto> ToProductDto(this IEnumerable<Product> products) =>
        products.Select(ToProductDto);

    public static ProductImageDto ToProductImageDto(this ProductImage productImage)
    {
        var imageUrl = string.Concat(UriComposer.BaseAzUrl, productImage.Name);

        return new(imageUrl, productImage.Name, productImage.IsMain);
    }

    public static IEnumerable<ProductImageDto> ToProductImageDto(this IEnumerable<ProductImage> productImages) =>
        productImages.Select(ToProductImageDto);
}