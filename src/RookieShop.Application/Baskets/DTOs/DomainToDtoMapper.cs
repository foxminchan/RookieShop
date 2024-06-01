using RookieShop.Domain.Entities.BasketAggregator;

namespace RookieShop.Application.Baskets.DTOs;

public static class DomainToDtoMapper
{
    public static BasketDto ToBasketDto(this Basket basket)
    {
        var basketDetails = basket.BasketDetails.ToBasketDetailDto().ToList();

        return new(
            basket.AccountId,
            basket.TotalPrice(),
            basketDetails);
    }

    public static IEnumerable<BasketDto> ToBasketDto(this IEnumerable<Basket> baskets)
        => baskets.Select(ToBasketDto);

    public static BasketDetailDto ToBasketDetailDto(this BasketDetail basketDetail) =>
        new(basketDetail.Id,
            basketDetail.Quantity,
            basketDetail.Price);

    public static IEnumerable<BasketDetailDto> ToBasketDetailDto(this IEnumerable<BasketDetail> basketDetails)
        => basketDetails.Select(ToBasketDetailDto);
}