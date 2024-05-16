using RookieShop.Application.Baskets.DTOs;

namespace RookieShop.ApiService.ViewModels.Baskets;

public static class DtoToViewModelMapper
{
    public static BasketVm ToBasketVm(this BasketDto basketDto)
    {
        var basketDetails = basketDto.BasketDetails.Select(x => x.ToBasketDetailVm()).ToList();

        return new(
            basketDto.AccountId,
            basketDto.TotalPrice,
            basketDetails);
    }

    public static BasketDetailVm ToBasketDetailVm(this BasketDetailDto basketDetail) =>
        new(basketDetail.Id, basketDetail.Quantity, basketDetail.Price);
}