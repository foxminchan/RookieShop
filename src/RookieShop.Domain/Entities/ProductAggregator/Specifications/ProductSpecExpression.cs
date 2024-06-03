using Ardalis.Specification;

namespace RookieShop.Domain.Entities.ProductAggregator.Specifications;

public static class ProductSpecExpression
{
    public static ISpecificationBuilder<Product> ApplyOrdering(this ISpecificationBuilder<Product> builder,
        string? orderBy, bool isDescending) =>
        orderBy switch
        {
            nameof(Product.Name) => isDescending
                ? builder.OrderByDescending(product => product.Name)
                : builder.OrderBy(product => product.Name),
            nameof(Product.Price) => isDescending
                ? builder.OrderByDescending(product => product.Price.Price)
                : builder.OrderBy(product => product.Price.Price),
            nameof(Product.Price.PriceSale) => isDescending
                ? builder.OrderByDescending(product => product.Price.PriceSale)
                : builder.OrderBy(product => product.Price.PriceSale),
            nameof(Product.Status) => isDescending
                ? builder.OrderByDescending(product => product.Status)
                : builder.OrderBy(product => product.Status),
            _ => isDescending
                ? builder.OrderByDescending(product => product.Id)
                : builder.OrderBy(product => product.Id)
        };

    public static ISpecificationBuilder<Product> ApplyPaging(this ISpecificationBuilder<Product> builder, int pageIndex,
        int pageSize) =>
        builder
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
}