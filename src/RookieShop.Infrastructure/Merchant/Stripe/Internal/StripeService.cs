using RookieShop.Infrastructure.Merchant.Stripe.Abstractions;
using Stripe;

namespace RookieShop.Infrastructure.Merchant.Stripe.Internal;

public sealed class StripeService(
    TokenService tokenService,
    CustomerService customerService,
    ChargeService chargeService) : IStripeService
{
    public async Task<CustomerResource>
        CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken)
    {
        var tokenOptions = new TokenCreateOptions
        {
            Card = new TokenCardOptions
            {
                Name = resource.Card.Name,
                Number = resource.Card.Number,
                ExpYear = resource.Card.ExpiryYear,
                ExpMonth = resource.Card.ExpiryMonth,
                Cvc = resource.Card.Cvc
            }
        };

        var token = await tokenService.CreateAsync(tokenOptions, cancellationToken: cancellationToken);

        var customerOptions = new CustomerCreateOptions
        {
            Email = resource.Email,
            Name = resource.Name,
            Source = token.Id
        };

        var customer = await customerService.CreateAsync(customerOptions, cancellationToken: cancellationToken);

        return new(customer.Id, customer.Email, customer.Name);
    }

    public async Task<ChargeResource> CreateCharge(CreateChargeResource resource, CancellationToken cancellationToken)
    {
        var chargeOptions = new ChargeCreateOptions
        {
            Currency = resource.Currency,
            Amount = resource.Amount,
            ReceiptEmail = resource.ReceiptEmail,
            Customer = resource.CustomerId,
            Description = resource.Description
        };

        var charge = await chargeService.CreateAsync(chargeOptions, cancellationToken: cancellationToken);

        return new(charge.PaymentMethodDetails.Card.Last4, charge.PaymentMethodDetails.Card.Brand, charge.Id);
    }
}