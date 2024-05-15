using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.SeedWork;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence.Constants;

namespace RookieShop.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IDatabaseFacade, IDomainEventContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<Customer> Customers => Set<Customer>();

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
        modelBuilder.HasPostgresExtension(UniqueType.Extension);
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.DbContextAssembly);
    }
}