namespace RookieShop.Application.Reports.DTOs;

public sealed record DiffRevenueByMonthDto(string SourceMonthYear, string TargetMonthYear, decimal Diff);