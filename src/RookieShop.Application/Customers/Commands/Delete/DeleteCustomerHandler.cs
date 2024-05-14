using Ardalis.GuardClauses;
using Ardalis.Result;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Commands.Delete;

public sealed class DeleteCustomerHandler(IRepository<Customer> repository)
    : ICommandHandler<DeleteCustomerCommand, Result>
{
    public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, customer);

        customer.Delete();

        await repository.UpdateAsync(customer, cancellationToken);

        return Result.Success();
    }
}