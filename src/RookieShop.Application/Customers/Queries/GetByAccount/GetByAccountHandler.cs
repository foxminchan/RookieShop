using Ardalis.Result;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Specifications;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Queries.GetByAccount;

public sealed class GetByAccountHandler(IReadRepository<Customer> repository)
    : IQueryHandler<GetByAccountQuery, Result<CustomerDto?>>
{
    public async Task<Result<CustomerDto?>> Handle(GetByAccountQuery request, CancellationToken cancellationToken)
    {
        CustomerByIdSpec spec = new(request.AccountId);

        var customer = await repository.FirstOrDefaultAsync(spec, cancellationToken);

        return customer?.ToCustomerDto();
    }
}