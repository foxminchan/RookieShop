namespace RookieShop.ApiService.Endpoints.Reports;

public sealed record DiffRevenueByMonthRequest(int SourceMonth, int SourceYear, int TargetMonth, int TargetYear);