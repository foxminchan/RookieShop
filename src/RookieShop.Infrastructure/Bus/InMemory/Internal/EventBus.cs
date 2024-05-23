using RookieShop.Domain.SeedWork;

namespace RookieShop.Infrastructure.Bus.InMemory.Internal;

public sealed class EventBus(InMemoryMessageQueue queue) : IEventBus
{
    public async Task PublishAsync<T>(T @event, CancellationToken cancellation = default)
        where T : IIntegrationEvent
    {
        await queue.Writer.WriteAsync(@event, cancellation);
    }
}