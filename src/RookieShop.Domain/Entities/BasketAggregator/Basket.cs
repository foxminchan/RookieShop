using Ardalis.GuardClauses;
using RookieShop.Domain.Entities.ProductAggregator.Primitives;

namespace RookieShop.Domain.Entities.BasketAggregator;

public sealed class Basket(Guid accountId)
{
    public Guid AccountId { get; set; } = Guard.Against.NullOrEmpty(accountId);
    public ICollection<BasketDetail> BasketDetails { get; set; } = [];

    public void AddItems(BasketDetail basketDetail) => BasketDetails.Add(basketDetail);

    public decimal TotalPrice() => BasketDetails.Sum(x => x.ToPrice());

    public void UpdateBasketDetails(BasketDetail basketDetails)
    {
        Guard.Against.Null(basketDetails);

        var basketDetail = BasketDetails.FirstOrDefault(x => x.Id == basketDetails.Id);

        if (basketDetail is not null)
        {
            basketDetail.Quantity += basketDetails.Quantity;

            if (basketDetail.Quantity <= 0)
            {
                BasketDetails.Remove(basketDetail);
            }
        }
        else
        {
            AddItems(basketDetails);
        }
    }

    public static class Factory
    {
        public static Basket Create(Guid accountId, ProductId productId, int quantity, decimal price)
        {
            Basket basket = new(accountId)
            {
                AccountId = accountId
            };

            basket.AddItems(new(productId, quantity, price));

            return basket;
        }
    }

    public Basket MergeBasket(Basket basket)
    {
        Guard.Against.Null(basket);

        foreach (var basketDetail in basket.BasketDetails)
        {
            UpdateBasketDetails(basketDetail);
        }

        return this;
    }
}