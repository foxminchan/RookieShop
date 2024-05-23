using Refit;
using RookieShop.Storefront.Areas.User.Models;

namespace RookieShop.Storefront.Areas.User.Services;

public interface ICustomerService
{
    [Get("/customers/{id}")]
    Task<CustomerViewModel> GetCustomerByIdAsync(Guid id);

    [Get("/customers/account/{accountId}")]
    Task<CustomerViewModel?> GetCustomerByAccountAsync(Guid accountId);

    [Put("/customers")]
    Task UpdateCustomerAsync(CustomerViewModel customer);
}