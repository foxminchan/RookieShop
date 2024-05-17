using Ardalis.Result;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Reports.Queries.TopProductByMonth;

public sealed record TopProductByMonthQuery(int Month, int Year, int Limit)
    : IQuery<Result<IEnumerable<TopProductByMonthVm>>>;