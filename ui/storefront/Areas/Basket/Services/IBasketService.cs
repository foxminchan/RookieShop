using Refit;
using RookieShop.Storefront.Areas.Basket.Models;

namespace RookieShop.Storefront.Areas.Basket.Services;

public interface IBasketService
{
    [Get("/baskets/{id}")]
    Task<BasketViewModel> GetBasketAsync(Guid id);
}