using Ardalis.Specification;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.Domain.Entities.CategoryAggregator.Specifications;

public sealed class CategoryByIdSpec : Specification<Category>
{
    public CategoryByIdSpec(CategoryId id) => Query.Where(x => x.Id == id);
}