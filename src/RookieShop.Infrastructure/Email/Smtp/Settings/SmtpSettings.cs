namespace RookieShop.Infrastructure.Email.Smtp.Settings;

public sealed class SmtpSettings
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 587;
    public string Email { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
}