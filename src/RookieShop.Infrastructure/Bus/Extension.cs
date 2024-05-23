using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Bus.InMemory;
using RookieShop.Infrastructure.Bus.InMemory.Internal;

namespace RookieShop.Infrastructure.Bus;

public static class Extension
{
    public static IHostApplicationBuilder AddEventBus(this IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<InMemoryMessageQueue>();

        builder.Services.AddSingleton<IEventBus, EventBus>();

        return builder;
    }
}