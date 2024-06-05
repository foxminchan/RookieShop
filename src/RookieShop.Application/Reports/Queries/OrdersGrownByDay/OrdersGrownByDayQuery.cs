using Ardalis.Result;
using RookieShop.Application.Reports.DTOs;
using RookieShop.Domain.SharedKernel;

namespace RookieShop.Application.Reports.Queries.OrdersGrownByDay;

public sealed record OrdersGrownByDayQuery(DateTime? CurrentDate) : IQuery<Result<OrdersGrownByDayDto>>;