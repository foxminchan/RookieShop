namespace RookieShop.Storefront.Middlewares;

public sealed class RobotMiddleware(IHostApplicationBuilder builder) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.StartsWithSegments("/robots.txt"))
        {
            var robotsTxtPath = Path.Combine(builder.Environment.ContentRootPath, "robots.txt");
            var output = "User-agent: *  \nDisallow: /";
            if (File.Exists(robotsTxtPath)) output = await File.ReadAllTextAsync(robotsTxtPath);

            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(output);
        }
        else
        {
            await next(context);
        }
    }
}