using Ardalis.Specification;
using RookieShop.Domain.Entities.CategoryAggregator.Primitives;

namespace RookieShop.Domain.Entities.ProductAggregator.Specifications;

public sealed class ProductsFilterSpec : Specification<Product>
{
    public ProductsFilterSpec(int pageIndex, int pageSize, string? orderBy, bool isDescending, CategoryId? categoryId)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        if (categoryId is not null)
            Query.Where(product => product.Category!.Id == categoryId);

        Query
            .Where(product => product.Category!.Id == categoryId && !product.IsDeleted)
            .ApplyPaging(pageIndex, pageSize)
            .ApplyOrdering(orderBy, isDescending);
    }
}