using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp;

public interface ISmtpService
{
    Task SendEmailAsync(EmailMetadata emailMetadata, CancellationToken cancellationToken = default);
}