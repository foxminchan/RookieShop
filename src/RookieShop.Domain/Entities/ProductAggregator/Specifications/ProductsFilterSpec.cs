using Ardalis.Specification;
using Pgvector;
using Pgvector.EntityFrameworkCore;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.Domain.Entities.ProductAggregator.Specifications;

public sealed class ProductsFilterSpec : Specification<Product>
{
    public ProductsFilterSpec(int pageIndex, int pageSize, string? orderBy, bool isDescending = false)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        Query
            .ApplyPaging(pageIndex, pageSize)
            .ApplyOrdering(orderBy, isDescending);
    }

    public ProductsFilterSpec(int pageIndex, int pageSize, CategoryId categoryId, string? orderBy, bool isDescending)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        Query
            .Where(product => product.Category!.Id == categoryId)
            .ApplyPaging(pageIndex, pageSize)
            .ApplyOrdering(orderBy, isDescending);
    }

    public ProductsFilterSpec(int pageIndex, int pageSize, Vector vector)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        Query
            .ApplyPaging(pageIndex, pageSize)
            .OrderBy(c => c.Embedding!.CosineDistance(vector));
    }
}