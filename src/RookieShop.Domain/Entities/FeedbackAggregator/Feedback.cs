using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.FeedbackAggregator;

public sealed class Feedback : EntityBase, IAggregateRoot
{
    /// <summary>
    ///     EF mapping constructor
    /// </summary>
    public Feedback()
    {
    }

    public Feedback(string? content, int rating, ProductId productId, CustomerId? customerId)
    {
        Content = content;
        Rating = Guard.Against.OutOfRange(rating, nameof(rating), 1, 5);
        ProductId = Guard.Against.Default(productId);
        CustomerId = customerId;
    }

    public FeedbackId Id { get; set; } = new(Guid.NewGuid());
    public string? Content { get; set; }
    public int Rating { get; set; }
    public CustomerId? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public ProductId ProductId { get; set; }
    public Product Product { get; set; } = new();

    public void Update(string? content, int rating, ProductId productId, CustomerId? customerId)
    {
        Content = content;
        Rating = Guard.Against.OutOfRange(rating, nameof(rating), 1, 5);
        ProductId = Guard.Against.Default(productId);
        CustomerId = customerId;
    }
}