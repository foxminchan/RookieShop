using Ardalis.Result;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Commands.Create;

public sealed record CreateCustomerCommand(string Name, string Email, string Phone, Gender Gender, Guid? AccountId)
    : ICommand<Result<CustomerId>>;