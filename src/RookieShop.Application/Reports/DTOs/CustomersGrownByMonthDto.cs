namespace RookieShop.Application.Reports.DTOs;

public sealed class CustomersGrownByMonthDto
{
    public long PreviousTotalCustomers { get; set; }
    public long CurrentTotalCustomers { get; set; }
    public long GrownCustomers { get; set; }
}