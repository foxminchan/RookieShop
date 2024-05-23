using Ardalis.Result;
using RookieShop.Domain.Constants;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator.ValueObjects;

public sealed class ShippingAddress(string? street, string? city, string? province) : ValueObject
{
    public string? Street { get; set; } = street;
    public string? City { get; set; } = city;
    public string? Province { get; set; } = province;

    public static Result<ShippingAddress>? Create(string? street, string? city, string? province)
    {
        if (!string.IsNullOrWhiteSpace(street) && street.Length > DataLength.Medium)
            return Result<ShippingAddress>.Invalid(
                new ValidationError($"Street must be less than {DataLength.Medium} characters"));

        if (!string.IsNullOrWhiteSpace(city) && city.Length > DataLength.Medium)
            return Result<ShippingAddress>.Invalid(
                new ValidationError($"City must be less than {DataLength.Medium} characters"));

        if (!string.IsNullOrWhiteSpace(province) && province.Length > DataLength.Medium)
            return Result<ShippingAddress>.Invalid(
                new ValidationError($"Province must be less than {DataLength.Medium} characters"));

        return new ShippingAddress(street, city, province);
    }

    public override string ToString() => $"{Street}, {City}, {Province}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ToString();
    }
}