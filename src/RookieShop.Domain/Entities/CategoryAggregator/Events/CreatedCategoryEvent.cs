using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.CategoryAggregator.Events;

public sealed class CreatedCategoryEvent(CategoryId categoryId, string? categoryName, string? description) : EventBase
{
    public CategoryId CategoryId { get; set; } = Guard.Against.Default(categoryId);
    public string? CategoryName { get; set; } = Guard.Against.NullOrEmpty(categoryName);
    public string? Description { get; set; } = description;
}