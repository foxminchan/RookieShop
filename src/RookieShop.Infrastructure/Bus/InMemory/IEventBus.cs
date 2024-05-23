using RookieShop.Domain.SeedWork;

namespace RookieShop.Infrastructure.Bus.InMemory;

public interface IEventBus
{
    Task PublishAsync<T>(T @event, CancellationToken cancellation = default) where T : IIntegrationEvent;
}