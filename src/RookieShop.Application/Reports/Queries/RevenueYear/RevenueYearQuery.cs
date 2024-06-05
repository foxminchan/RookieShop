using Ardalis.Result;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Reports.Queries.RevenueYear;

public sealed record RevenueYearQuery(int Year) : IQuery<Result<IEnumerable<RevenueYearDto>>>;