﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.OrderAggregator;
using RookieShop.Persistence.Constants;

namespace RookieShop.Persistence.Configurations;

public sealed class OrderConfiguration : BaseConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderDetails));

        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new(value)
            )
            .HasDefaultValueSql(UniqueType.Algorithm)
            .ValueGeneratedOnAdd();

        builder.OwnsOne(p => p.Card, e =>
        {
            e.WithOwner();

            e.Property(c => c.Last4Digits)
                .HasMaxLength(4)
                .IsFixedLength();

            e.Property(c => c.BrandName)
                .HasMaxLength(DataLength.Medium);

            e.Property(c => c.ChargeId)
                .HasMaxLength(DataLength.Medium);
        }).UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.OwnsOne(p => p.ShippingAddress, e =>
        {
            e.WithOwner();

            e.Property(c => c.Street)
                .HasMaxLength(DataLength.Medium);

            e.Property(c => c.City)
                .HasMaxLength(DataLength.Medium);

            e.Property(c => c.Province)
                .HasMaxLength(DataLength.Medium);
        }).UsePropertyAccessMode(PropertyAccessMode.Property);

        builder.HasOne(p => p.Customer)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(e => e.Customer).AutoInclude();

        builder.Navigation(e => e.OrderDetails).AutoInclude();
    }
}