using System.Text.Json;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

namespace RookieShop.ApiService.ViewModels.Reports;

public static class DtoToViewModelMapper
{
    public static BestSellerProductsVm ToBestSellerProductsVm(this BestSellerProductsDto bestSellerProductsDto)
    {
        var price = JsonSerializer.Deserialize<ProductPrice>(bestSellerProductsDto.Price);

        return new(
            bestSellerProductsDto.ProductId,
            bestSellerProductsDto.ProductName,
            bestSellerProductsDto.TotalSoldQuantity,
            price,
            bestSellerProductsDto.ImageUrl
        );
    }

    public static List<BestSellerProductsVm> ToBestSellerProductsVm(this IEnumerable<BestSellerProductsDto> bestSellerProductsDtos) =>
        bestSellerProductsDtos.Select(ToBestSellerProductsVm).ToList();
}