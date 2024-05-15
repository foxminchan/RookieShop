using RookieShop.Domain.Entities.CustomerAggregator.Enums;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed class CreateCustomerRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Male;
    public Guid? AccountId { get; set; }
}