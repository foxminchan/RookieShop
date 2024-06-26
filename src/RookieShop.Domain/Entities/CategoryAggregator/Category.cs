﻿using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.CategoryAggregator;

public sealed class Category : EntityBase, ISoftDelete, IAggregateRoot
{
    /// <summary>
    ///     EF mapping constructor
    /// </summary>
    public Category()
    {
    }

    public Category(string title, string? description)
    {
        Name = Guard.Against.NullOrEmpty(title);
        Description = description;
    }

    public CategoryId Id { get; set; } = new(Guid.NewGuid());
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public ICollection<Product>? Products { get; set; } = [];

    public void Update(string name, string? description)
    {
        Name = Guard.Against.NullOrEmpty(name);
        Description = description;
    }
}