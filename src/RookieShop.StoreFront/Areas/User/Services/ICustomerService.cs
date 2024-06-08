using Refit;
using RookieShop.Storefront.Areas.User.Models;
using RookieShop.Storefront.Constants;

namespace RookieShop.Storefront.Areas.User.Services;

public interface ICustomerService
{
    [Get("/customers/{id}")]
    Task<CustomerViewModel> GetCustomerByIdAsync(Guid id);

    [Get("/customers/account/{accountId}")]
    Task<CustomerViewModel?> GetCustomerByAccountAsync(Guid accountId);

    [Put("/customers")]
    Task UpdateCustomerAsync(CustomerViewModel customer);

    [Post("/customers")]
    Task CreateCustomerAsync(CustomerRequest request, [Header(HeaderName.IdempotencyKey)] Guid requestId);
}