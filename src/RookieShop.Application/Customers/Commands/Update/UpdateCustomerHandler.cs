using System.Text.Json;
using Ardalis.GuardClauses;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Commands.Update;

public sealed class UpdateCustomerHandler(IRepository<Customer> repository, ILogger<UpdateCustomerHandler> logger)
    : ICommandHandler<UpdateCustomerCommand, Result<CustomerDto>>
{
    public async Task<Result<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, customer);

        customer.Update(request.Name, request.Email, request.Phone, request.Gender, request.AccountId);

        logger.LogInformation("[{Command}] - Updating customer {@Customer}", nameof(UpdateCustomerCommand),
            JsonSerializer.Serialize(customer));

        await repository.UpdateAsync(customer, cancellationToken);

        return customer.ToCustomerDto();
    }
}