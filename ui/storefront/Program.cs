using Ardalis.ListStartupServices;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RookieShop.Infrastructure.OpenTelemetry;
using RookieShop.Storefront.Configurations;
using RookieShop.Storefront.Options;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

builder.ConfigureOpenTelemetry();

builder.Services.AddControllersWithViews();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.Configure<ServiceConfig>(config => config.Services = [.. builder.Services]);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = _ => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.AddWebServices(appSettings.ApiEndpoint);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.Use(async (ctx, next) =>
{
    await next();

    if (ctx.Response is { StatusCode: 404, HasStarted: false })
    {
        ctx.Request.Path = "/Error/PageNotFound";
        await next();
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
