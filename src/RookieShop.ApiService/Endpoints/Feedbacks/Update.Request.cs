using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class UpdateFeedbackRequest
{
    public FeedbackId Id { get; set; }
    public ProductId ProductId { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
    public CustomerId? CustomerId { get; set; }
}