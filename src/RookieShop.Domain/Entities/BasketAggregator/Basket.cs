using Ardalis.GuardClauses;

namespace RookieShop.Domain.Entities.BasketAggregator;

public sealed class Basket(Guid accountId)
{
    public Guid AccountId { get; set; } = Guard.Against.NullOrEmpty(accountId);
    public ICollection<BasketDetail> BasketDetails { get; set; } = [];

    public void AddItems(BasketDetail basketDetail) => BasketDetails.Add(basketDetail);

    public decimal TotalPrice() => BasketDetails.Sum(x => x.ToPrice());

    public void UpdateBasketDetails(BasketDetail basketDetails)
    {
        var basketDetail = BasketDetails.FirstOrDefault(x => x.Id == basketDetails.Id);

        basketDetail?.Update(basketDetails.Quantity, basketDetails.Price);
    }

    public static class Factory
    {
        public static Basket Create(Guid accountId, List<BasketDetail> basketDetails)
        {
            Basket basket = new(accountId);

            foreach (var basketDetail in basketDetails.Select(item => new BasketDetail(item.Id, item.Quantity, item.Price)))
            {
                basket.AddItems(basketDetail);
            }

            return basket;
        }
    }
}