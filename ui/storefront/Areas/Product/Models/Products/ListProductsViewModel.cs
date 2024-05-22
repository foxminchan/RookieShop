using System.Text.Json.Serialization;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Product.Models.Products;

public sealed class ListProductsViewModel : BaseListItemViewModel
{
    [JsonPropertyName("products")] public List<ProductViewModel> Products { get; set; } = [];
}