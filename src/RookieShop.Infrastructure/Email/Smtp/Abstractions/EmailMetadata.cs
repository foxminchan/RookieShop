namespace RookieShop.Infrastructure.Email.Smtp.Abstractions;

public sealed record EmailMetadata(
    string? Body,
    string? Subject,
    string? To,
    string? Bcc = null,
    string? Cc = null);