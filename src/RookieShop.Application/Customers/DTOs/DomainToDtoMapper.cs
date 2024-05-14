using RookieShop.Domain.Entities.CustomerAggregator;

namespace RookieShop.Application.Customers.DTOs;

public static class DomainToDtoMapper
{
    public static CustomerDto ToCustomerDto(this Customer customer) =>
        new(customer.Id, customer.Name, customer.Email, customer.Phone, customer.Gender, customer.AccountId);

    public static IEnumerable<CustomerDto> ToCustomerDto(this IEnumerable<Customer> customers) =>
        customers.Select(ToCustomerDto);
}