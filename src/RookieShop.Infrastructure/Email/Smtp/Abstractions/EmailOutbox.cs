﻿namespace RookieShop.Infrastructure.Email.Smtp.Abstractions;

public sealed class EmailOutbox
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string? Body { get; set; }
    public string? Subject { get; set; }
    public string? To { get; set; }
    public string? Cc { get; set; }
    public string? Bcc { get; set; }
    public bool IsSent { get; set; }
}