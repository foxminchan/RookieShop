using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.FeedbackAggregator;

public sealed class Feedback : EntityBase, IAggregateRoot
{
    public FeedbackId Id { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
    public Customer? Customer { get; set; }
    public Product Product { get; set; } = new();
}