using RookieShop.Application.Orders.Command.Create;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Infrastructure.Merchant.Stripe;
using RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

namespace RookieShop.Application.Orders.Services;

public sealed class OrderService(IStripeService stripeService) : IOrderService
{
    public async Task<ChargeResource> ProcessPaymentAsync(CreateOrderCommand request, Customer customer, Basket basket,
        CancellationToken cancellationToken)
    {
        CreateCardResource card = new(
            request.CardHolderName!,
            request.Number!,
            request.ExpiryYear!,
            request.ExpiryMonth!,
            request.Cvc!);

        CreateCustomerResource resource = new(customer.Email, customer.Name, card);

        var customerResource = await stripeService.CreateCustomerAsync(resource, cancellationToken);

        CreateChargeResource chargeResource = new(
            basket.TotalPrice(),
            customerResource.CustomerId,
            customerResource.Email,
            "Payment for order");

        return await stripeService.CreateChargeAsync(chargeResource, cancellationToken);
    }
}