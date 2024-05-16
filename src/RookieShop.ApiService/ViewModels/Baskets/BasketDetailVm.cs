using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Baskets;

public sealed record BasketDetailVm(
    ProductId Id,
    int Quantity,
    decimal Price);