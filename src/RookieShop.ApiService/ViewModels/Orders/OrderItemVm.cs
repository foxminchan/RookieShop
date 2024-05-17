using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Orders;

public sealed record OrderItemVm(ProductId Id, int Quantity, decimal Price);