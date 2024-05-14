using RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

namespace RookieShop.Infrastructure.Merchant.Stripe;

public interface IStripeService
{
    Task<CustomerResource> CreateCustomerAsync(CreateCustomerResource resource, CancellationToken cancellationToken);
    Task<ChargeResource> CreateChargeAsync(CreateChargeResource resource, CancellationToken cancellationToken);
}