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
            order,
            "Order Status ",
            $"{Directory.GetCurrentDirectory()}/Templates/Order.cshtml",
            notification.Order.Customer?.Email);

        await smtpService.SendEmailAsync(metadata, cancellationToken);
    }
}