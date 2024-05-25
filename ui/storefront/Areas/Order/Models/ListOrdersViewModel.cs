using System.Text.Json.Serialization;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class ListOrdersViewModel : BaseListItemViewModel
{
    [JsonPropertyName("orders")] public List<OrderViewModel> Orders { get; set; } = [];
}