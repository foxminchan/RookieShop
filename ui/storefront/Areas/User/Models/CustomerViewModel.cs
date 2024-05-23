using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.User.Models;

public sealed class CustomerViewModel
{
    [JsonPropertyName("id")] public Guid Id { get; set; }

    [JsonPropertyName("name")]
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    [Required(ErrorMessage = "Phone is required")]
    [Phone(ErrorMessage = "Invalid phone number")]
    public string? Phone { get; set; }

    [JsonPropertyName("gender")] public Gender Gender { get; set; }

    [JsonPropertyName("accountId")] public Guid AccountId { get; set; }
}