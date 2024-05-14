using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Pgvector;
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
        price, decimal priceSale)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Quantity = Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
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
    public Category? Category { get; set; }
    public ICollection<ProductImage>? ProductImages { get; set; } = [];
    public ICollection<OrderDetail>? OrderDetails { get; set; } = [];
    public IReadOnlyCollection<Feedback>? Feedbacks { get; set; } = [];
    public bool IsDeleted { get; set; }

    public void Delete() => IsDeleted = true;

    public void Update(string name, string? description, int quantity, decimal price, decimal priceSale,
        CategoryId categoryId = default)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
        Quantity = Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
        Status = quantity > 0 ? ProductStatus.InStock : ProductStatus.OutOfStock;
        Price = ProductPrice.Create(price, priceSale);

        if (categoryId != default) Category!.Id = categoryId;
    }

    public void DeleteImage(ProductImageId id) => ProductImages!.Remove(ProductImages!.First(x => x.Id == id));

    public void AddImages(List<ProductImage>? productImages)
    {
        if (productImages is null)
            return;

        foreach (var productImage in productImages)
        {
            ProductImages!.Add(productImage);
        }
    }

    public static class Factory
    {
        public static Product Create(
            string name,
            string? description,
            int quantity,
            decimal price,
            decimal priceSale,
            IEnumerable<ProductImage>? productImages,
            CategoryId categoryId = default)

        {
            Product product = new(name, description, quantity, price, priceSale);

            if (categoryId != default) product.Category!.Id = categoryId;

            if (productImages is null)
                return product;

            foreach (var productImage in productImages) product.ProductImages!.Add(productImage);

            return product;
        }
    }
}