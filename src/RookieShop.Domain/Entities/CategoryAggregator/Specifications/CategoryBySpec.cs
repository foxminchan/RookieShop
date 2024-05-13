using Ardalis.Specification;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.Domain.Entities.CategoryAggregator.Specifications;

public sealed class CategoryBySpec : Specification<Category>
{
    public CategoryBySpec(CategoryId id) => Query.Where(x => x.Id == id);
}