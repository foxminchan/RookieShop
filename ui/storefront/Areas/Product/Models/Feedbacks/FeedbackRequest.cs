using System.ComponentModel.DataAnnotations;
using Refit;

namespace RookieShop.Storefront.Areas.Product.Models.Feedbacks;

public sealed class FeedbackRequest
{
    [AliasAs("rating")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }

    [AliasAs("content")]
    [MaxLength(500, ErrorMessage = "Content must be less than 500 characters")]
    public string? Content { get; set; }

    [AliasAs("productId")]
    [Required(ErrorMessage = "Product Id is required")]
    public Guid ProductId { get; set; }

    [AliasAs("customerId")]
    [Required(ErrorMessage = "Customer Id is required")]
    public Guid? AccountId { get; set; }
}