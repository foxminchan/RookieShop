using Ardalis.Result;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Queries.List;

public sealed class ListCustomersHandler(IReadRepository<Customer> repository)
    : IQueryHandler<ListCustomersQuery, PagedResult<IEnumerable<CustomerDto>>>
{
    public async Task<PagedResult<IEnumerable<CustomerDto>>> Handle(ListCustomersQuery request,
        CancellationToken cancellationToken)
    {
        CustomersFilterSpec spec = new(request.PageIndex, request.PageSize, request.Name);

        var customers = await repository.ListAsync(spec, cancellationToken);

        var totalRecords = await repository.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

        PagedInfo pagedInfo = new(request.PageIndex, request.PageSize, totalPages, totalRecords);

        return new(pagedInfo, customers.ToCustomerDto());
    }
}