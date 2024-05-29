using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using RookieShop.IdentityService.Constants;
using RookieShop.IdentityService.Options;

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
        new(AuthScope.Read, "Read Access to API"),
        new(AuthScope.Write, "Write Access to API"),
        new(AuthScope.All, "Read and Write Access to API")
    ];

    public static IEnumerable<ApiResource> ApiResources =>
    [
        new()
        {
            Name = "api.rookie-shop",
            DisplayName = "Rookie Shop API",
            Scopes = { AuthScope.Read, AuthScope.Write }
        }
    ];

    public static IEnumerable<Client> Clients(ClientSettings client) =>
    [
        new()
        {
            ClientId = "ro.client",
            ClientName = "Resource Owner Client",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new("secret".Sha256()) },
            AllowedScopes = { AuthScope.Read, AuthScope.Write }
        },
        new()
        {
            ClientId = "api-swagger-ui",
            ClientName = "Rookie Shop API",
            ClientSecrets = { new("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.Code,
            RequireConsent = false,
            RequirePkce = true,
            RedirectUris = { $"{client.Swagger}/swagger/oauth2-redirect.html" },
            PostLogoutRedirectUris = { $"{client.Swagger}/swagger/oauth2-redirect.html" },
            AllowedCorsOrigins = { client.Swagger },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                AuthScope.Read,
                AuthScope.Write
            }
        },
        new()
        {
            ClientId = "store-front",
            ClientName = "Store Front",
            ClientSecrets = { new("secret".Sha256()) },
            AllowedGrantTypes = [GrantType.AuthorizationCode],
            RedirectUris = { $"{client.StoreFront}/signin-oidc" },
            PostLogoutRedirectUris = { $"{client.StoreFront}/signout-callback-oidc" },
            AllowedCorsOrigins = { $"{client.StoreFront}" },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                AuthScope.Read,
                AuthScope.Write
            }
        },
        new()
        {
            ClientId = "back-office",
            ClientName = "Back Office",
            ClientSecrets = { new("secret".Sha256()) },
            AllowedGrantTypes = [GrantType.AuthorizationCode],
            RedirectUris = { $"{client.Backoffice}/api/auth/callback/duende-identity-service" },
            PostLogoutRedirectUris = { $"{client.Backoffice}" },
            AllowedCorsOrigins = { $"{client.Backoffice}" },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                AuthScope.All
            }
        }
    ];
}