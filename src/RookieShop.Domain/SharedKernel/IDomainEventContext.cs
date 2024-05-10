using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.SharedKernel;

public interface IDomainEventContext
{
    IEnumerable<EventBase> GetDomainEvents();
}