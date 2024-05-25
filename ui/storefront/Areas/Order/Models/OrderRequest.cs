using System.ComponentModel.DataAnnotations;
using Refit;
using RookieShop.Storefront.Areas.Basket.Models;
using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.Order.Models;

public class OrderRequest
{
    [AliasAs("paymentMethod")]
    [JsonPropertyName("paymentMethod")]
    [Required(ErrorMessage = "Please select payment method")]
    public PaymentMethod PaymentMethod { get; set; }

    [AliasAs("cardHolderName")]
    [JsonPropertyName("cardHolderName")]
    [MaxLength(50, ErrorMessage = "Card holder name must be less than 50 characters")]
    public string? CardHolderName { get; set; }

    [AliasAs("number")]
    [JsonPropertyName("number")]
    [MaxLength(16, ErrorMessage = "Card number must be less than 16 characters")]
    [Display(Name = "Card Number")]
    public string? CardNumber { get; set; }

    [AliasAs("expiryYear")]
    [JsonPropertyName("expiryYear")]
    [Range(2021, 2030, ErrorMessage = "Expiry year must be between 2021 and 2030")]
    [Display(Name = "Expiry Year")]
    public int? ExpiryYear { get; set; }

    [AliasAs("expiryMonth")]
    [JsonPropertyName("expiryMonth")]
    [Range(1, 12, ErrorMessage = "Expiry month must be between 1 and 12")]
    [Display(Name = "Expiry Month")]
    public int? ExpiryMonth { get; set; }

    [AliasAs("cvc")]
    [JsonPropertyName("cvc")]
    [MaxLength(4, ErrorMessage = "CVC must be less than 4 characters")]
    [Display(Name = "CVC")]
    public string? Cvc { get; set; }

    [AliasAs("street")]
    [JsonPropertyName("street")]
    [MaxLength(100, ErrorMessage = "Street must be less than 100 characters")]
    [Display(Name = "Shipping Address")]
    public string? Street { get; set; }

    [AliasAs("city")]
    [JsonPropertyName("city")]
    [MaxLength(50, ErrorMessage = "City must be less than 50 characters")]
    public string? City { get; set; }

    [AliasAs("province")]
    [JsonPropertyName("province")]
    [MaxLength(50, ErrorMessage = "Province must be less than 50 characters")]
    public string? Province { get; set; }

    [AliasAs("accountId")]
    [JsonPropertyName("accountId")]
    [Required(ErrorMessage = "Please login to place order")]
    public Guid AccountId { get; set; }
}