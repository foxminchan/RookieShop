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
            Name = "Books",
            Description = 
                "A book is a medium for recording information in the form of writing or images, typically composed of many pages bound together and protected by a cover."
        };

        yield return new()
        {
            Name = "Toys",
            Description = 
                "A toy is an item that is used in play, especially one designed for such use. Playing with toys can be an enjoyable means of training young children for life in society."
        };

        yield return new()
        {
            Name = "Comics",
            Description = 
                "A comic book, also called comic magazine or (in the United Kingdom and Ireland) simply comic, is a publication that consists of comics art in the form of sequential juxtaposed panels that represent individual scenes."
        };

        yield return new()
        {
            Name = "Artworks",
            Description = 
                "Artwork is a term that describes art that is created to be appreciated for its own sake. It generally refers to visual art, such as paintings, sculptures, and printmaking."
        };

        yield return new()
        {
            Name = "Souvenirs",
            Description = 
                "A souvenir is an object that is kept as a reminder of a person, place, or event. The object itself may have intrinsic value, or be a symbol of experience."
        };

        yield return new()
        {
            Name = "Stationery",
            Description = 
                "Stationery is a mass noun referring to commercially manufactured writing materials, including cut paper, envelopes, writing implements, continuous form paper, and other office supplies."
        };
    }
}