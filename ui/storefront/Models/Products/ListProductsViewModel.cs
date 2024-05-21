using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Models.Products;

public sealed class ListProductsViewModel : BaseListItemViewModel
{
    [JsonPropertyName("products")] public List<ProductViewModel> Products { get; set; } = [];
}