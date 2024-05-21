using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Models.Feedbacks;

public sealed class ListFeedbackViewModel : BaseListItemViewModel
{
    [JsonPropertyName("feedbacks")] public List<FeedbackViewModel> Feedbacks { get; set; } = [];
}