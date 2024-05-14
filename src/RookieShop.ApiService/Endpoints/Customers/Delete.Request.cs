using RookieShop.Domain.Entities.CustomerAggregator.Primitives;

namespace RookieShop.ApiService.Endpoints.Customers;

public sealed record DeleteCustomerRequest(CustomerId Id);