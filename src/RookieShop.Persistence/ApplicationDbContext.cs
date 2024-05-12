using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using RookieShop.Domain.SeedWork;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence.Constants;
using SmartEnum.EFCore;

namespace RookieShop.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IDatabaseFacade, IDomainEventContext
{
    public IEnumerable<EventBase> GetDomainEvents()
    {
        var domainEntities = ChangeTracker
            .Entries<EntityBase>()
            .Where(x => x.Entity.DomainEvents.Count != 0)
            .ToImmutableList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToImmutableList();

        domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

        return domainEvents;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureSmartEnum();
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.HasPostgresExtension(VectorType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.DbContextAssembly);
    }
}