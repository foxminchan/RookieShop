namespace RookieShop.ApiService.ViewModels.Baskets;

public sealed record BasketVm(
    Guid AccountId,
    decimal TotalPrice,
    List<BasketDetailVm> BasketDetails);