using MediatR;

namespace RookieShop.Domain.SeedWork;

public sealed class EventWrapper(EventBase @event) : INotification
{
    public EventBase Event { get; } = @event;
}