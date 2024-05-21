namespace RookieShop.Infrastructure.Email.Smtp.Abstractions;

public sealed record EmailMetadata(
    object Model,
    string? Subject,
    string? Template,
    string? To,
    string? Bcc = null,
    string? Cc = null);