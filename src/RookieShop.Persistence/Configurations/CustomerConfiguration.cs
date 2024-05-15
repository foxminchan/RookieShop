using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.CustomerAggregator;
using RookieShop.Domain.Entities.CustomerAggregator.Enums;
using RookieShop.Persistence.Constants;

namespace RookieShop.Persistence.Configurations;

public sealed class CustomerConfiguration : BaseConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
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

        builder.Property(p => p.Email)
            .HasMaxLength(DataLength.Medium)
            .IsRequired();

        builder.Property(p => p.Phone)
            .HasMaxLength(DataLength.Small)
            .IsRequired();

        builder.HasData(GetSampleData());
    }

    private static IEnumerable<Customer> GetSampleData()
    {
        yield return new()
        {
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            Phone = "0123456789",
            Gender = Gender.Male,
            AccountId = null
        };

        yield return new()
        {
            Name = "William Smith",
            Email = "william.smith@gmail.com",
            Phone = "0123456789",
            Gender = Gender.Male,
            AccountId = null
        };

        yield return new()
        {
            Name = "Maria Garcia",
            Email = "maria.garcia@gmail.com",
            Phone = "0123456789",
            Gender = Gender.Female,
            AccountId = null
        };

        yield return new()
        {
            Name = "Anna Johnson",
            Email = "anna.johnson@gmail.com",
            Phone = "0123456789",
            Gender = Gender.Female,
            AccountId = null
        };

        yield return new()
        {
            Name = "Nhan Nguyen",
            Email = "nguyenxuannhan407@gmail.com",
            Phone = "0123456789",
            Gender = Gender.Male,
            AccountId = new("7055bbfe-25c6-4b33-98cd-fc2b9fb4bb1a")
        };

        yield return new()
        {
            Name = "Fox Min Chan",
            Email = "nguyenxuannhan.dev@gmail.com",
            Phone = "0123456789",
            Gender = Gender.Male,
            AccountId = new("e5255692-c91f-43ba-937c-059895fd67a2")
        };
    }
}