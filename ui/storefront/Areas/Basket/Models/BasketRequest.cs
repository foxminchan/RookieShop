using System.ComponentModel.DataAnnotations;
using Refit;

namespace RookieShop.Storefront.Areas.Basket.Models;

public sealed class BasketRequest
{
    [AliasAs("accountId")]
    public Guid? AccountId { get; set; }

    [AliasAs("id")]
    [Required(ErrorMessage = "Product Id is required")]
    public Guid ProductId { get; set; }

    [AliasAs("quantity")]
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }

    [AliasAs("price")]
    [Required(ErrorMessage = "Price is required")]
    [Range(0.0, double.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]
    public decimal Price { get; set; }
}