using RookieShop.Domain.Entities.CustomerAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed record CreateCustomerResponse(CustomerId Id);