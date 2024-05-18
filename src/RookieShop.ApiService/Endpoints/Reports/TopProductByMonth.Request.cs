namespace RookieShop.ApiService.Endpoints.Reports;

public sealed record TopProductByMonthRequest(int Month, int Year, int Limit);