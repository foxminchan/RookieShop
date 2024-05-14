using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;

namespace RookieShop.ApiService.ViewModels.Customers;

public sealed record CustomerVm(
    CustomerId Id,
    string Name,
    string Email,
    string Phone,
    Gender Gender,
    string? AccountId);