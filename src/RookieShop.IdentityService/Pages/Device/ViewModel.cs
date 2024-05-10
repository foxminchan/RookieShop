// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

namespace RookieShop.IdentityService.Pages.Device;

public sealed class ViewModel
{
    public string? ClientName { get; set; }
    public string? ClientUrl { get; set; }
    public string? ClientLogoUrl { get; set; }
    public bool AllowRememberConsent { get; set; }

    public IEnumerable<ScopeViewModel> IdentityScopes { get; set; } = [];
    public IEnumerable<ScopeViewModel> ApiScopes { get; set; } = [];
}

public sealed class ScopeViewModel
{
    public string? Value { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public bool Emphasize { get; set; }
    public bool Required { get; set; }
    public bool Checked { get; set; }
}