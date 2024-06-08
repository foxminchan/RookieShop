namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class OrderItemFromRequest
{
    public Guid ProductId { get; set; }

    public decimal PriceSale { get; set; }

    public string? ProductName { get; set; }

    public int Quantity { get; set; }
}