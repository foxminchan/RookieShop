using Ardalis.Specification;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;

namespace RookieShop.Domain.Entities.CustomerAggregator.Specifications;

public sealed class CustomerByIdSpec : Specification<Customer>
{
    public CustomerByIdSpec(CustomerId customerId) =>
        Query.Where(customer => customer.Id == customerId && !customer.IsDeleted);
}