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
                    OrderStatus.Pending => "Pending",
                    OrderStatus.Shipping => "Processing",
                    OrderStatus.Canceled => "Canceled",
                    OrderStatus.Completed => "Completed",
                    _ => "Unknown" }
            }",
            "Order Status",
            notification.Order.Customer?.Email);

        await smtpService.SendEmailAsync(metadata, cancellationToken);
    }
}