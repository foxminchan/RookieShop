namespace RookieShop.Domain.Entities.BasketAggregator;

public sealed class Basket(string accountId)
{
    public string AccountId { get; set; } = accountId;
    public ICollection<BasketDetail> BasketDetails { get; set; } = [];

    public void AddItems(BasketDetail basketDetail) => BasketDetails.Add(basketDetail);

    public static class Factory
    {
        public static Basket Create(string accountId, List<BasketDetail> basketDetails)
        {
            Basket basket = new(accountId);

            foreach (var basketDetail in basketDetails)
            {
                basket.AddItems(basketDetail);
            }

            return basket;
        }
    }

    public void UpdateBasketDetails(BasketDetail basketDetails)
    {
        var basketDetail = BasketDetails.FirstOrDefault(x => x.Id == basketDetails.Id);

        if (basketDetail is null) return;

        basketDetail.Quantity = basketDetails.Quantity;
        basketDetail.Price = basketDetails.Price;
    }
}