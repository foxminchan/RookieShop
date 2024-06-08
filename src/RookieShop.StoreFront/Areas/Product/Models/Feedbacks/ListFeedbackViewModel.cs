using System.Text.Json.Serialization;
using RookieShop.Storefront.Models;

namespace RookieShop.Storefront.Areas.Product.Models.Feedbacks;

public sealed class ListFeedbackViewModel : BaseListItemViewModel
{
    [JsonPropertyName("feedbacks")] public List<FeedbackViewModel> Feedbacks { get; set; } = [];
}