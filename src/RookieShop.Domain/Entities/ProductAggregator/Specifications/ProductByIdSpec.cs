using Ardalis.Specification;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Domain.Entities.ProductAggregator.Specifications;

public sealed class ProductByIdSpec : Specification<Product>
{
    public ProductByIdSpec(ProductId id) => Query.Where(product => product.Id == id && !product.IsDeleted);
}