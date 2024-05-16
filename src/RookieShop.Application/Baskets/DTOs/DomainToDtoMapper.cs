using RookieShop.Domain.Entities.BasketAggregator;

namespace RookieShop.Application.Baskets.DTOs;

public static class DomainToDtoMapper
{
    public static BasketDto ToBasketDto(this Basket basket)
    {
        var basketDetails = basket.BasketDetails.Select(x => x.ToBasketDetailDto()).ToList();

        return new(
            basket.AccountId,
            basket.TotalPrice(),
            basketDetails);
    }

    public static BasketDetailDto ToBasketDetailDto(this BasketDetail basketDetail) =>
        new(basketDetail.Id,
            basketDetail.Quantity,
            basketDetail.Price);
}