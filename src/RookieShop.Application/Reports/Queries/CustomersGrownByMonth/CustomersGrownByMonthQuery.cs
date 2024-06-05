using Ardalis.Result;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Reports.Queries.CustomersGrownByMonth;

public sealed record CustomersGrownByMonthQuery(int Month, int Year)
    : IQuery<Result<CustomersGrownByMonthDto>>;