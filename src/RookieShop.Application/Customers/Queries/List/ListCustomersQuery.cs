using Ardalis.Result;
using RookieShop.Application.Customers.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Customers.Queries.List;

public sealed record ListCustomersQuery(int PageIndex, int PageSize, string? Name)
    : IQuery<PagedResult<IEnumerable<CustomerDto>>>;