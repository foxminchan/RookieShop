using System.Text.Json;
using Ardalis.Result;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Commands.Create;

public sealed class CreateCustomerHandler(IRepository<Customer> repository, ILogger<CreateCustomerHandler> logger)
    : ICommandHandler<CreateCustomerCommand, Result<CustomerId>>
{
    public async Task<Result<CustomerId>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = new(request.Name, request.Email, request.Phone, request.Gender, request.AccountId);

        logger.LogInformation("[{Command}] - Creating customer {@Customer}", nameof(CreateCustomerCommand),
            JsonSerializer.Serialize(customer));

        var result = await repository.AddAsync(customer, cancellationToken);

        return result.Id;
    }
}