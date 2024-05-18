using System.ComponentModel.DataAnnotations;

namespace RookieShop.Storefront;

public sealed class Settings
{
    [Required(ErrorMessage = "The API endpoint is required.")]
    public string ApiEndpoint { get; set; } = string.Empty;
}