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
    }
}