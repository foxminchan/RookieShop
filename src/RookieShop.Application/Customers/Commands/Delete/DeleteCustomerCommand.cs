using Ardalis.Result;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Commands.Delete;

public sealed record DeleteCustomerCommand(CustomerId Id) : ICommand<Result>;