using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Domain.Entities.CustomerAggregator.Primitives;

namespace RookieShop.Application.Customers.DTOs;

public sealed record CustomerDto(
    CustomerId Id,
    string Name,
    string Email,
    string Phone,
    Gender Gender,
    Guid? AccountId);