using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

public sealed class ProductPrice(decimal price = 0, decimal priceSale = 0) : ValueObject
{
    public decimal Price { get; set; } = price;
    public decimal PriceSale { get; set; } = priceSale;

    public static ProductPrice Create(decimal price, decimal priceSale)
    {
        Guard.Against.Negative(price);
        Guard.Against.Negative(priceSale);

        if (priceSale > price)
            throw new ValidationException("Price sale must be less than or equal to price");

        return new(price, priceSale);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Price;
        yield return PriceSale;
    }
}