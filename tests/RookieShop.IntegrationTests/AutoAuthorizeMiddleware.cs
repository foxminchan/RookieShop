using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace RookieShop.IntegrationTests;

public class AutoAuthorizeMiddleware(RequestDelegate next)
{
    public const string IdentityId = "7055bbfe-25c6-4b33-98cd-fc2b9fb4bb1a";

    public async Task Invoke(HttpContext httpContext)
    {
        var identity = new ClaimsIdentity("cookies");

        identity.AddClaim(new(ClaimTypes.NameIdentifier, IdentityId));
        identity.AddClaim(new(ClaimTypes.NameIdentifier, IdentityId));
        identity.AddClaim(new(ClaimTypes.Name, IdentityId));

        httpContext.User.AddIdentity(identity);

        await next(httpContext);
    }
}