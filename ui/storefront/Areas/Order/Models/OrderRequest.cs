using System.ComponentModel.DataAnnotations;
using Refit;
using RookieShop.Storefront.Areas.Basket.Models;

namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class OrderRequest
{
    [AliasAs("paymentMethod")]
    [Required(ErrorMessage = "Please select payment method")]
    public PaymentMethod PaymentMethod { get; set; }

    [AliasAs("cardHolderName")]
    [MaxLength(50, ErrorMessage = "Card holder name must be less than 50 characters")]
    public string? CardHolderName { get; set; }

    [AliasAs("number")]
    [MaxLength(16, ErrorMessage = "Card number must be less than 16 characters")]
    [Display(Name = "Card Number")]
    public string? CardNumber { get; set; }

    [AliasAs("expiryYear")]
    [Range(2021, 2030, ErrorMessage = "Expiry year must be between 2021 and 2030")]
    [Display(Name = "Expiry Year")]
    public int? ExpiryYear { get; set; }

    [AliasAs("expiryMonth")]
    [Range(1, 12, ErrorMessage = "Expiry month must be between 1 and 12")]
    [Display(Name = "Expiry Month")]
    public int? ExpiryMonth { get; set; }

    [AliasAs("cvc")]
    [MaxLength(4, ErrorMessage = "CVC must be less than 4 characters")]
    [Display(Name = "CVC")]
    public string? Cvc { get; set; }

    [AliasAs("street")]
    [MaxLength(100, ErrorMessage = "Street must be less than 100 characters")]
    [Display(Name = "Shipping Address")]
    public string? Street { get; set; }

    [AliasAs("city")]
    [MaxLength(50, ErrorMessage = "City must be less than 50 characters")]
    public string? City { get; set; }

    [AliasAs("province")]
    [MaxLength(50, ErrorMessage = "Province must be less than 50 characters")]
    public string? Province { get; set; }

    [AliasAs("accountId")]
    [Required(ErrorMessage = "Please login to place order")]
    public Guid AccountId { get; set; }
}