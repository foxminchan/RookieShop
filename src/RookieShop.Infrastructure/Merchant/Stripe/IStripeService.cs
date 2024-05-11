using RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

namespace RookieShop.Infrastructure.Merchant.Stripe;

public interface IStripeService
{
    Task<CustomerResource> CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken);
    Task<ChargeResource> CreateCharge(CreateChargeResource resource, CancellationToken cancellationToken);
}