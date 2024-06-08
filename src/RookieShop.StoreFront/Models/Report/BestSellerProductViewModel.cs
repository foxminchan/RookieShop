using System.Text.Json.Serialization;
using RookieShop.Storefront.Areas.Product.Models.Products;

namespace RookieShop.Storefront.Models.Report;

public sealed class BestSellerProductViewModel
{
    [JsonPropertyName("productId")] public Guid ProductId { get; set; }

    [JsonPropertyName("productName")] public string? ProductName { get; set; }

    [JsonPropertyName("totalSoldQuantity")]
    public int TotalSoldQuantity { get; set; }

    [JsonPropertyName("imageUrl")] public string? ImageUrl { get; set; }

    [JsonPropertyName("price")]
    public ProductPrice? Price { get; set; } 
}