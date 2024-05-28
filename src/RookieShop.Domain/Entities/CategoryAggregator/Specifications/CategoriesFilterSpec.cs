using Ardalis.Specification;

namespace RookieShop.Domain.Entities.CategoryAggregator.Specifications;

public sealed class CategoriesFilterSpec : Specification<Category>
{
    public CategoriesFilterSpec(int pageIndex, int pageSize, string? search = null)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        if (!string.IsNullOrEmpty(search)) Query.Where(p => p.Name.Contains(search));

        Query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
    }
}