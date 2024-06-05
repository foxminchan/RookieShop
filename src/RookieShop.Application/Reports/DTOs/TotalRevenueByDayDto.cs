namespace RookieShop.Application.Reports.DTOs;

public sealed class TotalRevenueByDayDto
{
    public DateTime Date { get; set; }
    public long TotalRevenue { get; set; }
}