using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Feedbacks;

public sealed class CreateFeedbackRequest
{
    public ProductId ProductId { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
    public CustomerId? CustomerId { get; set; }
}