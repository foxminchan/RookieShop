using System.Net.Mime;

namespace RookieShop.Storefront.Middlewares;

public sealed class RobotMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/Robots.txt"))
        {
            var robotsTxtPath = Path.Combine(Directory.GetCurrentDirectory(), "Robots.txt");
            var robotsTxtContent = "User-agent: *\nDisallow: /";
            if (File.Exists(robotsTxtPath)) robotsTxtContent = await File.ReadAllTextAsync(robotsTxtPath);
            context.Response.ContentType = MediaTypeNames.Text.Plain;
            await context.Response.WriteAsync(robotsTxtContent);
        }
        else
        {
            await next(context);
        }
    }
}