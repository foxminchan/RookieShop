using System.ComponentModel.DataAnnotations;

namespace RookieShop.IdentityService.Pages.Account.Register;

public sealed class InputModel
{
    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string? Username { get; set; }

    [Required]
    [RegularExpression(@"^\d{8,16}$", ErrorMessage = "Phone number must be 8-16 digits.")]
    public string? PhoneNumber { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$",
        ErrorMessage =
            "Password must be 8-15 characters and contain at least one uppercase letter, one lowercase letter, and one digit.")]
    public string? Password { get; set; }

    [Required]
    [Compare(nameof(Password))]
    public string? ConfirmPassword { get; set; }

    public string? ReturnUrl { get; set; }

    public string? Button { get; set; }
}