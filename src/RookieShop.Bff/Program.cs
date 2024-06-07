using Duende.Bff.Yarp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RookieShop.Bff;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBff()
    .AddRemoteApis();

Configuration config = new();
builder.Configuration.Bind("BFF", config);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        options.DefaultSignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "__Host-bff";
        options.Cookie.SameSite = SameSiteMode.Strict;
    })
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Authority = config.Authority;
        options.ClientId = config.ClientId;
        options.ClientSecret = config.ClientSecret;

        options.ResponseType = OpenIdConnectResponseType.Code;
        options.ResponseMode = OpenIdConnectResponseMode.Query;

        options.GetClaimsFromUserInfoEndpoint = true;
        options.MapInboundClaims = false;
        options.SaveTokens = true;

        options.Scope.Clear();
        foreach (var scope in config.Scopes)
        {
            options.Scope.Add(scope);
        }
    });


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseBff();

app.MapBffManagementEndpoints();

if (!string.IsNullOrEmpty(config.RemoteUrl))
{
    app.MapRemoteBffApiEndpoint("/api", $"{config.RemoteUrl}/categories")
        .RequireAccessToken();
}

await app.RunAsync();