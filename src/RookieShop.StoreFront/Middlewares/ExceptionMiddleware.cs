namespace RookieShop.Storefront.Middlewares;

public sealed class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.Redirect("/Account/Login");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "[{Middleware}] Exception occurred: {ExceptionMessage}", nameof(ExceptionMiddleware),
                ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.Redirect(context.Response.StatusCode == StatusCodes.Status404NotFound
            ? "/Error/NotFound"
            : "/Home/Error");

        await context.Response.WriteAsync(exception.Message);
    }
}