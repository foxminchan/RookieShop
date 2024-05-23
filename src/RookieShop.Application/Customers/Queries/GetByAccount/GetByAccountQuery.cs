using Ardalis.Result;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Queries.GetByAccount;

public sealed record GetByAccountQuery(Guid AccountId) : IQuery<Result<CustomerDto?>>;