using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator.IntegrationEvents;

public sealed record OrderInvoiceIntegrationEvent<T>(Guid Id, T Metadata) : IIntegrationEvent where T : notnull;