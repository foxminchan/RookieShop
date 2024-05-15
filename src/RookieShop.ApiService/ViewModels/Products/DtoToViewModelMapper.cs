using RookieShop.ApiService.ViewModels.Feedbacks;
using RookieShop.Application.Products.DTOs;

namespace RookieShop.ApiService.ViewModels.Products;

public static class DtoToViewModelMapper
{
    public static ProductVm ToProductVm(this ProductDto product)
    {
        var feedbacks = product.Feedbacks?.ToFeedbackVm();

        return new(product.Id,
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
}