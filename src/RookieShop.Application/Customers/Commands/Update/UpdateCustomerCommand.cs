using Ardalis.Result;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Commands.Update;

public sealed record UpdateCustomerCommand(
    CustomerId Id,
    string Name,
    string Email,
    string Phone,
    Gender Gender,
    Guid? AccountId) : ICommand<Result<CustomerDto>>;