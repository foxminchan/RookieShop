using System.ComponentModel.DataAnnotations;
using Refit;
using RookieShop.Storefront.Areas.Basket.Models;

namespace RookieShop.Storefront.Areas.Order.Models;

public sealed class OrderRequest
{
    [AliasAs("paymentMethod")]
    [Required(ErrorMessage = "Please select payment method")]
    public PaymentMethod PaymentMethod { get; set; }

    [AliasAs("street")]
    [MaxLength(100, ErrorMessage = "Street must be less than 100 characters")]
    [Display(Name = "Shipping Address")]
    public string? Street { get; set; }

    [AliasAs("city")]
    [MaxLength(50, ErrorMessage = "City must be less than 50 characters")]
    [Display(Name = "District/City")]
    public string? City { get; set; }

    [AliasAs("province")]
    [MaxLength(50, ErrorMessage = "Province must be less than 50 characters")]
    [Display(Name = "State/Province")]
    public string? Province { get; set; }

    [AliasAs("last4")]
    public string? Last4 { get; set; }

    [AliasAs("brand")]
    public string? Brand { get; set; }

    [AliasAs("chargeId")]
    public string? ChargeId { get; set; }

    [AliasAs("accountId")]
    [Required(ErrorMessage = "Please login to place order")]
    public Guid AccountId { get; set; }
}