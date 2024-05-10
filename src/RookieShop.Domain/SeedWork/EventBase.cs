using MediatR;

namespace RookieShop.Domain.SeedWork;

public abstract class EventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}