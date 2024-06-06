using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.CategoryAggregator.Events;

public sealed class DeletedCategoryEvent(CategoryId categoryId) : EventBase
{
    public CategoryId CategoryId { get; set; } = Guard.Against.Default(categoryId);
}