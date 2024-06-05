using Ardalis.Result;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Reports.Queries.TotalRevenueByDay;

public sealed record TotalRevenueByDayQuery(DateTime? CurrentDate) : IQuery<Result<TotalRevenueByDayDto>>;