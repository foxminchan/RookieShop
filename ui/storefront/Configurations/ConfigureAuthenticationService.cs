using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RookieShop.Domain.Constants;
using RookieShop.Storefront.Options;

namespace RookieShop.Storefront.Configurations;

public static class ConfigureAuthenticationService
{
    public static IHostApplicationBuilder AddAuthenticationService(this IHostApplicationBuilder builder,
        OpenIdSettings openIdSettings)
    {
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.SaveTokens = true;
                options.RequireHttpsMetadata = false;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ResponseType = OpenIdConnectResponseType.Code;

                options.Authority = openIdSettings.Authority;
                options.ClientId = openIdSettings.ClientId;
                options.ClientSecret = openIdSettings.ClientSecret;

                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add(AuthScope.Read);
                options.Scope.Add(AuthScope.Write);
            });

        return builder;
    }
}