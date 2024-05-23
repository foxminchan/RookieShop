using RookieShop.Application.Products.DTOs;

namespace RookieShop.ApiService.ViewModels.Products;

public static class DtoToViewModelMapper
{
    public static ProductVm ToProductVm(this ProductDto product) =>
        new(product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price,
            product.PriceSale,
            product.ImageUrl,
            product.AverageRating,
            product.TotalReviews,
            product.Category);

    public static List<ProductVm> ToProductVm(this IEnumerable<ProductDto> products) =>
        products.Select(ToProductVm).ToList();
}