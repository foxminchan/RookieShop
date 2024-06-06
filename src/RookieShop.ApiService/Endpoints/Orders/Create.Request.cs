using RookieShop.Domain.Entities.OrderAggregator.Enums;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class CreateOrderRequest
{
    public PaymentMethod PaymentMethod { get; set; }
    public string? Last4 { get; set; }
    public string? Brand { get; set; }
    public string? ChargeId { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public Guid AccountId { get; set; }
}