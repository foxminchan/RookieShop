using Ardalis.GuardClauses;
using RookieShop.Infrastructure.Merchant.Stripe.Abstractions;
using Stripe;

namespace RookieShop.Infrastructure.Merchant.Stripe.Internal;

public sealed class StripeService(
    TokenService tokenService,
    CustomerService customerService,
    ChargeService chargeService) : IStripeService
{
    public async Task<CustomerResource>
        CreateCustomerAsync(CreateCustomerResource resource, CancellationToken cancellationToken)
    {
        var tokenOptions = new TokenCreateOptions
        {
            Card = new TokenCardOptions
            {
                Name = Guard.Against.NullOrEmpty(resource.Card.Name),
                Number = Guard.Against.NullOrEmpty(resource.Card.Number),
                ExpYear = Guard.Against.NullOrEmpty(resource.Card.ExpiryYear),
                ExpMonth = Guard.Against.NullOrEmpty(resource.Card.ExpiryMonth),
                Cvc = Guard.Against.NullOrEmpty(resource.Card.Cvc)
            }
        };

        var token = await tokenService.CreateAsync(tokenOptions, cancellationToken: cancellationToken);

        var customerOptions = new CustomerCreateOptions
        {
            Email = Guard.Against.NullOrEmpty(resource.Email),
            Name = Guard.Against.NullOrEmpty(resource.Name),
            Source = token.Id
        };

        var customer = await customerService.CreateAsync(customerOptions, cancellationToken: cancellationToken);

        return new(customer.Id, customer.Email, customer.Name);
    }

    public async Task<ChargeResource> CreateChargeAsync(CreateChargeResource resource, CancellationToken cancellationToken)
    {
        var chargeOptions = new ChargeCreateOptions
        {
            Currency = resource.Currency ?? "USD",
            Amount = decimal.ToInt64(resource.Amount),
            ReceiptEmail = resource.ReceiptEmail,
            Customer = resource.CustomerId,
            Description = resource.Description
        };

        var charge = await chargeService.CreateAsync(chargeOptions, cancellationToken: cancellationToken);

        return new(charge.PaymentMethodDetails.Card.Last4, charge.PaymentMethodDetails.Card.Brand, charge.Id);
    }
}