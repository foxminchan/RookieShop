using MediatR;
using RookieShop.Application.Orders.DTOs;
using RookieShop.Domain.Entities.OrderAggregator.Events;
using RookieShop.Infrastructure.Email.Smtp;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Application.Orders.Events;

public sealed class UpdatedOrderHandler(ISmtpService smtpService) : INotificationHandler<UpdatedOrderEvent>
{
    public async Task Handle(UpdatedOrderEvent notification, CancellationToken cancellationToken)
    {
        var order = notification.Order.ToOrderDto();

        EmailMetadata metadata = new(
            $"Your order {order.Id} has been updated to {order.OrderStatus}",
            "Order Status ",
            notification.Order.Customer?.Email);

        await smtpService.SendEmailAsync(metadata, cancellationToken);
    }
}