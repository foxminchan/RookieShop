using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Persistence.Configurations;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.CreatedDate)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.UpdateDate)
            .HasDefaultValue(DateTime.UtcNow);

        builder.Property(e => e.Version)
            .HasDefaultValue(Guid.NewGuid())
            .IsConcurrencyToken();
    }
}