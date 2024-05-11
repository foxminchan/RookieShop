﻿using Duende.IdentityServer.Models;
using RookieShop.Domain.Constants;
using Duende.IdentityServer;

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

    public static IEnumerable<Client> Clients(IConfiguration configuration) =>
    [
        new()
        {
            ClientId = "ro.client",
            ClientName = "Resource Owner Client",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new("secret".Sha256()) },
            AllowedScopes = { AuthScope.Read, AuthScope.Write },
        },
        new()
        {
            ClientId = "api-swagger-ui",
            ClientName = "Rookie Shop API",
            ClientSecrets = { new("secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.Code,
            RequireConsent = false,
            RequirePkce = true,
            RedirectUris = { $"{configuration["Client:Swagger"]}/swagger/oauth2-redirect.html" },
            PostLogoutRedirectUris = { $"{configuration["ClientUrl:Swagger"]}/swagger/oauth2-redirect.html" },
            AllowedCorsOrigins = { configuration["Client:Swagger"] ?? throw new InvalidOperationException() },
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
            RedirectUris = { $"{configuration["Client:StoreFront"]}/api/auth/callback/sample-identity-server" },
            PostLogoutRedirectUris = { $"{configuration["Client:StoreFront"]}" },
            AllowedCorsOrigins = { $"{configuration["Client:StoreFront"]}" },
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
            RedirectUris = { $"{configuration["Client:BackOffice"]}/api/auth/callback/sample-identity-server" },
            PostLogoutRedirectUris = { $"{configuration["Client:BackOffice"]}" },
            AllowedCorsOrigins = { $"{configuration["Client:BackOffice"]}" },
            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                AuthScope.Read,
                AuthScope.Write
            }
        }
    ];
}