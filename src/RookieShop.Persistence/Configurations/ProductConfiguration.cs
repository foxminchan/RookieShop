﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.ProductAggregator;
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

        builder.Property(p => p.ImageName)
            .HasMaxLength(DataLength.Medium);

        builder.Property(p => p.Embedding)
            .HasColumnType(VectorType.DataType);

        builder.OwnsOne(
            p => p.Price,
            e => e.ToJson()
        );

        builder.HasOne(p => p.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Navigation(e => e.Category)
            .AutoInclude();

        builder.Navigation(p => p.Feedbacks)
            .AutoInclude();

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}