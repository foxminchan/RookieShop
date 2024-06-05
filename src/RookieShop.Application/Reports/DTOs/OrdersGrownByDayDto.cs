namespace RookieShop.Application.Reports.DTOs;

public sealed class OrdersGrownByDayDto
{
    public long TodayCount { get; set; }
    public long YesterdayCount { get; set; }
    public long GrowthPercentage { get; set; }
    public DateTime CurrentDate { get; set; }
}