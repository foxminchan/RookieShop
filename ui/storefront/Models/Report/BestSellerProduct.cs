using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Models.Report;

public class BestSellerProduct
{
    [JsonPropertyName("productId")] public Guid ProductId { get; set; }

    [JsonPropertyName("productName")] public string? ProductName { get; set; }

    [JsonPropertyName("totalSoldQuantity")]
    public int TotalSoldQuantity { get; set; }

    [JsonPropertyName("imageUrl")] public string? ImageUrl { get; set; }
}