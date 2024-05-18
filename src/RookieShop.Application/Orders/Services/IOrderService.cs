using RookieShop.Application.Orders.Command.Create;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Infrastructure.Merchant.Stripe.Abstractions;

namespace RookieShop.Application.Orders.Services;

public interface IOrderService
{
    Task<ChargeResource> ProcessPaymentAsync(CreateOrderCommand request, Customer customer, Basket basket,
        CancellationToken cancellationToken);
}