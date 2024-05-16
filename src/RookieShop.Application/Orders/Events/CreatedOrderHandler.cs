using MediatR;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.BasketAggregator;
using RookieShop.Domain.Entities.OrderAggregator.Events;
using RookieShop.Infrastructure.Cache.Redis;
using RookieShop.Infrastructure.Email.Smtp;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Application.Orders.Events;

public sealed class CreatedOrderHandler(IRedisService redisService, ISmtpService<OrderDto> smtpService)
    : INotificationHandler<CreatedOrderEvent>
{
    public async Task Handle(CreatedOrderEvent notification, CancellationToken cancellationToken)
    {
        var order = notification.Order.ToOrderDto();

        EmailMetadata<OrderDto> metadata = new(
            order,
            "Order Confirmation",
            $"{Directory.GetCurrentDirectory()}/Templates/Order.cshtml",
            notification.Email);

        var tasks = new List<Task>
        {
            redisService.HashRemoveAsync(nameof(Basket), notification.AccountId.ToString()),
            smtpService.SendEmailAsync(metadata, cancellationToken)
        };

        await Task.WhenAll(tasks);
    }
}