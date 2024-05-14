using RookieShop.Application.Customers.DTOs;

namespace RookieShop.ApiService.ViewModels.Customers;

public static class DtoToViewModelMapper
{
    public static CustomerVm ToCustomerVm(this CustomerDto customer) =>
        new(customer.Id, customer.Name, customer.Email, customer.Phone, customer.Gender, customer.AccountId);

    public static List<CustomerVm> ToCustomerVm(this IEnumerable<CustomerDto> customers) =>
        customers.Select(ToCustomerVm).ToList();
}