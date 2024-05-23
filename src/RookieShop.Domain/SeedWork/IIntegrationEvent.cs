using MediatR;

namespace RookieShop.Domain.SeedWork;

public interface IIntegrationEvent : INotification
{
    Guid Id { get; init; }
}