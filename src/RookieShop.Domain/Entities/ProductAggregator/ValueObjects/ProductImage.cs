using Ardalis.Result;
using RookieShop.Domain.Constants;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

public sealed class ProductImage(string? name, string? alt, bool isMain) : ValueObject
{
    public ProductImageId Id { get; set; } = new(new());
    public string? Name { get; set; } = name;
    public string? Alt { get; set; } = alt;
    public bool IsMain { get; set; } = isMain;

    public static Result<ProductImage>? Create(string? name, string? alt, bool isMain = false)
    {
        if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(alt))
            return null;

        if (!string.IsNullOrWhiteSpace(name) && name.Length > DataLength.Medium)
            return Result.Invalid(
                new ValidationError($"Name length must be less than or equal to {DataLength.Medium}"));

        if (!string.IsNullOrWhiteSpace(alt) && alt.Length > DataLength.Medium)
            return Result.Invalid(new ValidationError($"Alt length must be less than or equal to {DataLength.Medium}"));

        return new ProductImage(name, alt, isMain);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name ?? string.Empty;
        yield return Alt ?? string.Empty;
    }
}