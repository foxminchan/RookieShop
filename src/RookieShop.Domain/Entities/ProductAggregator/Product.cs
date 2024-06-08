using Pgvector;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Enums;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.ProductAggregator;

public sealed class Product : EntityBase, ISoftDelete, IAggregateRoot
{
    /// <summary>
    ///     EF mapping constructor
    /// </summary>
    public Product()
    {
    }

    public Product(string name, string? description, int quantity, decimal
        price, decimal priceSale, string? imageName, CategoryId? categoryId)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Quantity = Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
        Status = quantity > 0 ? ProductStatus.InStock : ProductStatus.OutOfStock;
        Price = ProductPrice.Create(price, priceSale);
        ImageName = imageName;
        CategoryId = categoryId;
    }

    public ProductId Id { get; set; } = new(Guid.NewGuid());
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public ProductStatus Status { get; set; } = ProductStatus.InStock;
    public ProductPrice Price { get; set; } = new();
    public string? ImageName { get; set; }
    public double AverageRating { get; set; }
    public int TotalReviews { get; set; }
    public CategoryId? CategoryId { get; set; }
    [JsonIgnore] public Vector Embedding { get; set; } = default!;
    public Category? Category { get; set; }
    public ICollection<OrderDetail>? OrderDetails { get; set; } = [];
    public ICollection<Feedback>? Feedbacks { get; set; } = [];
    public bool IsDeleted { get; set; }

    public void Delete() => IsDeleted = true;

    public void RemoveStock(int quantityDesired)
    {
        Quantity -= Guard.Against.OutOfRange(quantityDesired, nameof(quantityDesired), 0, int.MaxValue);
        if (Status == ProductStatus.InStock && Quantity == 0) Status = ProductStatus.OutOfStock;
    }

    public void Update(string name, string? description, int quantity, decimal price, decimal priceSale,
        string? imageName, CategoryId? categoryId, ProductStatus status)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Quantity = Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
        Status = status;
        Price = ProductPrice.Create(price, priceSale);
        ImageName = imageName;
        CategoryId = categoryId;
        Status = Guard.Against.EnumOutOfRange(status);
    }

    public void UpdateRating(double rating, int totalFeedback) =>
        (AverageRating, TotalReviews) = (rating, totalFeedback);
}