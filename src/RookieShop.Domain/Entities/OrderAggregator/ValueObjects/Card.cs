using Ardalis.Result;
using RookieShop.Domain.Constants;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.OrderAggregator.ValueObjects;

public sealed class Card(string? brandName, string? last4Digits, string? chargeId) : ValueObject
{
    public string? BrandName { get; set; } = brandName;
    public string? Last4Digits { get; set; } = last4Digits;
    public string? ChargeId { get; set; } = chargeId;

    public static Result<Card>? Create(string? brandName, string? last4Digits, string? chargeId)
    {
        if (!string.IsNullOrWhiteSpace(brandName) && brandName.Length > DataLength.Medium)
            return Result.Invalid(
                new ValidationError($"Brand name length must be less than or equal to {DataLength.Medium}"));

        if (!string.IsNullOrWhiteSpace(last4Digits) && last4Digits.Length >= DataLength.Micro)
            return Result.Invalid(new ValidationError($"Last 4 digits length must be less than {DataLength.Micro}"));

        if (!string.IsNullOrWhiteSpace(chargeId) && chargeId.Length > DataLength.Medium)
            return Result.Invalid(
                new ValidationError($"Charge ID length must be less than or equal to {DataLength.Medium}"));

        return new Card(brandName, last4Digits, chargeId);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return BrandName ?? string.Empty;
        yield return Last4Digits ?? string.Empty;
        yield return ChargeId ?? string.Empty;
    }
}