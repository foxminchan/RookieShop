using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.FeedbackAggregator;
using RookieShop.Persistence.Constants;

namespace RookieShop.Persistence.Configurations;

public sealed class FeedbackConfiguration : BaseConfiguration<Feedback>
{
    public override void Configure(EntityTypeBuilder<Feedback> builder)
    {
        base.Configure(builder);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new(value)
            )
            .HasDefaultValueSql(UniqueType.Algorithm)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Content)
            .HasMaxLength(DataLength.Max)
            .IsRequired();

        builder.Property(p => p.Rating)
            .IsRequired();

        builder.Navigation(p => p.Customer)
            .AutoInclude();

        builder.Navigation(p => p.Product)
            .AutoInclude();
    }
}