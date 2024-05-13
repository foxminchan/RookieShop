using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Pgvector;
using RookieShop.Domain.Entities.CategoryAggregator;
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

    public Product(string name, string description, int quantity, decimal
        price, decimal priceSale)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Quantity = Guard.Against.Negative(quantity);
        Status = quantity > 0 ? ProductStatus.InStock : ProductStatus.OutOfStock;
        Price = ProductPrice.Create(price, priceSale);
    }

    public ProductId Id { get; set; } = new(Guid.NewGuid());
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public ProductStatus Status { get; set; } = ProductStatus.InStock;
    public ProductPrice Price { get; set; } = new();
    [JsonIgnore] public Vector? Embedding { get; set; }
    public bool IsDeleted { get; set; }
    public Category? Category { get; set; }
    public List<ProductImage>? ProductImages { get; set; } = [];
}