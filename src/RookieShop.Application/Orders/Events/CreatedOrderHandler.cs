using MediatR;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Events;
using RookieShop.Domain.Entities.OrderAggregator.IntegrationEvents;
using RookieShop.Infrastructure.Bus.InMemory;
using RookieShop.Infrastructure.Cache.Redis;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Application.Orders.Events;

public sealed class CreatedOrderHandler(IRedisService redisService, IEventBus eventBus)
    : INotificationHandler<CreatedOrderEvent>
{
    public async Task Handle(CreatedOrderEvent notification, CancellationToken cancellationToken)
    {
        await redisService.HashRemoveAsync(nameof(Basket), notification.AccountId.ToString());

        EmailMetadata metadata = new(
            notification.Order.ToOrderDto(),
            "Order Confirmation",
            $"{Directory.GetCurrentDirectory()}/Templates/Order.cshtml",
            notification.Email);

        await eventBus.PublishAsync(new OrderInvoiceIntegrationEvent<EmailMetadata>(Guid.NewGuid(), metadata),
            cancellationToken);
    }
}