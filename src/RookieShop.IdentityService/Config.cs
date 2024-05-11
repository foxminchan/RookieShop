using Duende.IdentityServer.Models;

namespace RookieShop.IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    ];

    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new("scope1"),
        new("scope2")
    ];

    public static IEnumerable<Client> Clients =>
    [
        // m2m client credentials flow client
        new()
        {
            ClientId = "m2m.client",
            ClientName = "Client Credentials Client",

            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

            AllowedScopes = { "scope1" }
        },

        // interactive client using code flow + pkce
        new()
        {
            ClientId = "interactive",
            ClientSecrets = { new("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

            AllowedGrantTypes = GrantTypes.Code,

            RedirectUris = { "https://localhost:44300/signin-oidc" },
            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

            AllowOfflineAccess = true,
            AllowedScopes = { "openid", "profile", "scope2" }
        }
    ];
}