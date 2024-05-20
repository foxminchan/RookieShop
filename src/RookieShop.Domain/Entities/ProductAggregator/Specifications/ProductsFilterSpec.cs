using Ardalis.Specification;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.Domain.Entities.ProductAggregator.Specifications;

public sealed class ProductsFilterSpec : Specification<Product>
{
    public ProductsFilterSpec(int pageIndex, int pageSize, string? orderBy, bool isDescending,
        CategoryId?[]? categoryIds)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        if (categoryIds is not null && categoryIds.Length > 0)
            Query.Where(product => categoryIds.Contains(product.CategoryId));

        Query
            .Where(product => !product.IsDeleted)
            .ApplyPaging(pageIndex, pageSize)
            .ApplyOrdering(orderBy, isDescending);
    }
}