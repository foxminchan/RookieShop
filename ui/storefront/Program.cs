using Microsoft.Extensions.DependencyInjection.Extensions;
using RookieShop.ServiceDefaults;
using RookieShop.Storefront.Configurations;
using RookieShop.Storefront.Options;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.AddServiceDefaults();

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = _ => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.AddHealthCheck(appSettings);

builder.AddAuthenticationService(appSettings.OpenIdSettings);

builder.AddHttpServices(appSettings.BaseApiEndpoint);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapHealthCheck();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.UseStatusCodePages();

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/robots.txt"))
    {
        var robotsTxtPath = Path.Combine(app.Environment.ContentRootPath, "robots.txt");
        var output = "User-agent: *  \nDisallow: /";
        if (File.Exists(robotsTxtPath)) output = await File.ReadAllTextAsync(robotsTxtPath);

        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(output);
    }
    else
    {
        await next();
    }
});

app.MapControllerRoute(
    "Product",
    "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "User",
    "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "Order",
    "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();