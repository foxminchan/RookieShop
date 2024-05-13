using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.CategoryAggregator;
using RookieShop.Persistence.Constants;

namespace RookieShop.Persistence.Configurations;

public sealed class CategoryConfiguration : BaseConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
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

        builder.HasData(GetSampleData());
    }

    private static IEnumerable<Category> GetSampleData()
    {
        yield return new()
        {
            Name = "Book",
            Description =
                "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover."
        };

        yield return new()
        {
            Name = "Clothes",
            Description =
                "Clothes are items worn on the body. They are typically made of fabrics or textiles but over time have included garments made from animal skin or other thin sheets of materials put together."
        };

        yield return new()
        {
            Name = "Electronics",
            Description =
                "Electronics comprises the physics, engineering, technology and applications that deal with the emission, flow and control of electrons in vacuum and matter."
        };

        yield return new()
        {
            Name = "Furniture",
            Description =
                "Furniture refers to movable objects intended to support various human activities such as seating, eating, and sleeping."
        };

        yield return new()
        {
            Name = "Jewelry",
            Description =
                "Jewellery consists of small decorative items worn for personal adornment, such as brooches, rings, necklaces, earrings, pendants, bracelets, and cufflinks."
        };
    }
}