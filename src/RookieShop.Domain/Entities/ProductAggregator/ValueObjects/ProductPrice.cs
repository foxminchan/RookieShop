using Ardalis.Result;
using RookieShop.Domain.SeedWork;

namespace RookieShop.Domain.Entities.ProductAggregator.ValueObjects;

public sealed class ProductPrice(decimal price = 0, decimal priceSale = 0) : ValueObject
{
    public decimal Price { get; set; } = price;
    public decimal PriceSale { get; set; } = priceSale;

    public static Result<ProductPrice>? Create(decimal price, decimal priceSale)
    {
        if (price < 0)
            return Result.Invalid(new ValidationError("Price must be greater than or equal to 0"));

        if (priceSale < 0)
            return Result.Invalid(new ValidationError("Price sale must be greater than or equal to 0"));

        if (priceSale > price)
            return Result.Invalid(new ValidationError("Price sale must be less than or equal to price"));

        return new ProductPrice(price, priceSale);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Price;
        yield return PriceSale;
    }
}