using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using RookieShop.Storefront.Areas.Basket.Models;

namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class OrderFromRequest
{
    [Required(ErrorMessage = "Please select payment method")]
    [JsonRequired]
    public PaymentMethod PaymentMethod { get; set; }

    [MaxLength(100, ErrorMessage = "Street must be less than 100 characters")]
    [Display(Name = "Shipping Address")]
    public string? Street { get; set; }

    [MaxLength(50, ErrorMessage = "City must be less than 50 characters")]
    [Display(Name = "District/City")]
    public string? City { get; set; }

    [MaxLength(50, ErrorMessage = "Province must be less than 50 characters")]
    [Display(Name = "State/Province")]
    public string? Province { get; set; }

    [Required(ErrorMessage = "Please login to place order")]
    [JsonRequired]
    public Guid AccountId { get; set; }
}