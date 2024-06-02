namespace RookieShop.Application.Reports.DTOs;

public sealed class BestSellerProductsDto
{
    public Guid ProductId { get; set; }
    public string? ProductName { get; set; }
    public int TotalSoldQuantity { get; set; }
    public string Price { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}