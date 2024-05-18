using Ardalis.Result;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Reports.Queries.DiffRevenueByMonth;

public sealed record DiffRevenueByMonthQuery(
    int SourceMonth,
    int SourceYear,
    int TargetMonth,
    int TargetYear) : IQuery<Result<DiffRevenueByMonthDto?>>;