using Ardalis.Result;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Queries.Get;

public sealed record GetCustomerQuery(CustomerId Id) : IQuery<Result<CustomerDto>>;