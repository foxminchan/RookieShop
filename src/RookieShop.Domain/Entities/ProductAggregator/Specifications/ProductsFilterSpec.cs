using Ardalis.Specification;
using Pgvector;
using Pgvector.EntityFrameworkCore;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.Domain.Entities.ProductAggregator.Specifications;

public sealed class ProductsFilterSpec : Specification<Product>
{
    public ProductsFilterSpec(int pageIndex, int pageSize, string? orderBy, bool isDescending, string? search = null,
        CategoryId?[]? categoryIds = null)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        if (categoryIds is not null && categoryIds.Length > 0)
            Query.Where(product => categoryIds.Contains(product.CategoryId));

        if (!string.IsNullOrEmpty(search))
            Query.Where(product => product.Name.Contains(search));

        Query
            .Where(product => !product.IsDeleted)
            .ApplyPaging(pageIndex, pageSize)
            .ApplyOrdering(orderBy, isDescending);
    }

    public ProductsFilterSpec() => Query.Where(product => !product.IsDeleted);

    public ProductsFilterSpec(Vector vector, int pageIndex, int pageSize) =>
        Query.Where(product => !product.IsDeleted)
            .OrderBy(c => c.Embedding.CosineDistance(vector))
            .ApplyPaging(pageIndex, pageSize);
}