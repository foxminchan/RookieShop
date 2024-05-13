using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.ProductAggregator;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.Entities.ProductAggregator.ValueObjects;
using RookieShop.Persistence.Constants;

namespace RookieShop.Persistence.Configurations;

public sealed class ProductConfiguration : BaseConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
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

        builder.Property(p => p.Name)
            .HasMaxLength(DataLength.Medium)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(DataLength.Max)
            .IsRequired();

        builder.Property(p => p.Quantity)
            .HasDefaultValue(0)
            .IsRequired();

        builder.Property(p => p.Embedding)
            .HasColumnType(VectorType.DataType);

        builder.OwnsOne(
            p => p.Price,
            e => e.ToJson()
        );

        builder.OwnsMany(p => p.ProductImages, e =>
        {
            e.WithOwner().HasForeignKey(nameof(ProductId));

            e.HasKey(nameof(ProductImage.Id), nameof(ProductId));

            e.Property(p => p.Id)
                .HasConversion(
                    id => id.Value,
                    value => new(value)
                ).ValueGeneratedOnAdd();

            e.Property(p => p.Name)
                .HasMaxLength(DataLength.Medium)
                .IsRequired();

            e.Property(p => p.Alt)
                .HasMaxLength(DataLength.Medium)
                .IsRequired();
        });

        builder.Navigation(e => e.Category)
            .AutoInclude();

        builder.Navigation(e => e.Feedbacks)
            .AutoInclude();

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}