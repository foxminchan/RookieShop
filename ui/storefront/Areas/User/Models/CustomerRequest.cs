using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Refit;

namespace RookieShop.Storefront.Areas.User.Models;

public class CustomerRequest
{
    [AliasAs("name")]
    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
    public string? Name { get; set; }

    [AliasAs("email")]
    [JsonPropertyName("email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

    [AliasAs("phone")]
    [JsonPropertyName("phone")]
    [Required(ErrorMessage = "Phone is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string? Phone { get; set; }

    [AliasAs("gender")]
    [JsonPropertyName("gender")]
    [Required(ErrorMessage = "Gender is required")]
    public Gender Gender { get; set; }

    [AliasAs("accountId")]
    [JsonPropertyName("accountId")]
    [Required(ErrorMessage = "Account Id is required")]
    public Guid AccountId { get; set; }
}