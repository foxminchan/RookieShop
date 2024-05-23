using System.Threading.Channels;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Infrastructure.Bus.InMemory.Internal;

public sealed class InMemoryMessageQueue
{
    private readonly Channel<IIntegrationEvent> _channel = Channel.CreateUnbounded<IIntegrationEvent>();

    public ChannelWriter<IIntegrationEvent> Writer => _channel.Writer;

    public ChannelReader<IIntegrationEvent> Reader => _channel.Reader;
}