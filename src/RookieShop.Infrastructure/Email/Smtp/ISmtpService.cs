using RookieShop.Infrastructure.Email.Smtp.Abstractions;

namespace RookieShop.Infrastructure.Email.Smtp;

public interface ISmtpService<T> where T : notnull
{
    Task SendEmailAsync(EmailMetadata<T> emailMetadata, CancellationToken cancellationToken = default);
}