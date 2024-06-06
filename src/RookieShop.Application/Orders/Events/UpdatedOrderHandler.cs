using MediatR;
using RookieShop.Domain.Entities.OrderAggregator.Enums;
using RookieShop.Domain.Entities.OrderAggregator.Events;
using RookieShop.Infrastructure.Email.Smtp;
using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Application.Orders.Events;

public sealed class UpdatedOrderHandler(ISmtpService smtpService) : INotificationHandler<UpdatedOrderEvent>
{
    public async Task Handle(UpdatedOrderEvent notification, CancellationToken cancellationToken)
    {
        EmailMetadata metadata = new(
            $"Your order status has been updated to {
                notification.Order.OrderStatus switch {
                    OrderStatus.Pending => nameof(OrderStatus.Pending),
                    OrderStatus.Shipping => nameof(OrderStatus.Shipping),
                    OrderStatus.Canceled => nameof(OrderStatus.Canceled),
                    OrderStatus.Completed => nameof(OrderStatus.Completed),
                    _ => "Unknown" }
            }",
            "Order Status",
            notification.Order.Customer?.Email);

        await smtpService.SendEmailAsync(metadata, cancellationToken);
    }
}