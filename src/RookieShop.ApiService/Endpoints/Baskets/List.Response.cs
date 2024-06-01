using RookieShop.ApiService.ViewModels.Baskets;

namespace RookieShop.ApiService.Endpoints.Baskets;

public sealed record ListBasketsResponse(List<BasketVm> Baskets);