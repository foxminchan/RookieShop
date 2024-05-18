using RookieShop.Domain.Entities.OrderAggregator.Enums;

namespace RookieShop.ApiService.Endpoints.Orders;

public sealed class CreateOrderRequest
{
    public PaymentMethod PaymentMethod { get; set; }
    public string? CardHolderName { get; set; }
    public string? Number { get; set; }
    public string? ExpiryYear { get; set; }
    public string? ExpiryMonth { get; set; }
    public string? Cvc { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public Guid AccountId { get; set; }
}