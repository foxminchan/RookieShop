using Ardalis.Specification;

namespace RookieShop.Domain.Entities.CustomerAggregator.Specifications;

public sealed class CustomersFilterSpec : Specification<Customer>
{
    public CustomersFilterSpec(int pageIndex, int pageSize, string? name)
    {
        if (pageSize == 0) pageSize = int.MaxValue;

        Query
            .Where(x => !x.IsDeleted)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .OrderBy(customer => customer.Name);

        if (!string.IsNullOrWhiteSpace(name)) Query.Where(customer => customer.Name.Contains(name));
    }
}