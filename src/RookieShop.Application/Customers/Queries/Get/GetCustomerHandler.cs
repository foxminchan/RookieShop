using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Queries.Get;

public sealed class GetCustomerHandler(IReadRepository<Customer> repository)
    : IQueryHandler<GetCustomerQuery, Result<CustomerDto>>
{
    public async Task<Result<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        CustomerByIdSpec spec = new(request.Id);

        var customer = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        Guard.Against.NotFound(request.Id, customer);

        return customer.ToCustomerDto();
    }
}