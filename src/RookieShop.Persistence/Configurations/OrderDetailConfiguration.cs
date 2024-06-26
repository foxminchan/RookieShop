﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.Entities.OrderAggregator;

namespace RookieShop.Persistence.Configurations;

public sealed class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
{
    public override void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        base.Configure(builder);

        builder.HasKey(e => new { e.OrderId, e.ProductId });

        builder.Property(p => p.Quantity)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.HasOne(p => p.Order)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(p => p.Product)
            .AutoInclude();
    }
}