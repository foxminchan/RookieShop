using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RookieShop.Storefront.Areas.User.Models;

public sealed class CustomerViewModel : CustomerRequest
{
    [JsonPropertyName("id")]
    [Required(ErrorMessage = "Id is required")]
    [JsonRequired]
    public Guid Id { get; set; }
}