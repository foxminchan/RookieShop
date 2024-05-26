using Refit;
using RookieShop.Storefront.Areas.Basket.Models;
using RookieShop.Storefront.Constants;

namespace RookieShop.Storefront.Areas.Basket.Services;

public interface IBasketService
{
    [Get("/baskets/{id}")]
    Task<BasketViewModel> GetBasketAsync(Guid id);

    [Post("/baskets")]
    Task AddToBasketAsync(BasketRequest basketRequest, [Header(HeaderName.IdempotencyKey)] Guid requestId);

    [Delete("/baskets/items")]
    Task DeleteItemAsync([Query] DeleteItemRequest deleteItemRequest);
}