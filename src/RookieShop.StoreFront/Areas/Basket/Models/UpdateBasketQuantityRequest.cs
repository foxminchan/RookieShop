using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Refit;

namespace RookieShop.Storefront.Areas.Basket.Models;

public sealed class UpdateBasketQuantityRequest
{
    [AliasAs("accountId")]
    public Guid? AccountId { get; set; }

    [AliasAs("productId")]
    [Required(ErrorMessage = "Product Id is required")]
    [JsonRequired]
    public Guid ProductId { get; set; }

    [AliasAs("quantity")]
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
}