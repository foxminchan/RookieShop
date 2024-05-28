using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RookieShop.ServiceDefaults;
using RookieShop.Storefront.Configurations;
using RookieShop.Storefront.Middlewares;
using RookieShop.Storefront.Options;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.AddServiceDefaults();

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddWebOptimizer();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = _ => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.AddHealthCheck(appSettings);

builder.AddAuthenticationService(appSettings.OpenIdSettings);

builder.AddHttpServices(appSettings.BaseApiEndpoint);

builder.Services.AddMemoryCache();

builder.Services.AddScoped<CustomerInfoMiddleware>();

builder.Services.AddRouting(options => options.ConstraintMap["slugify"] = typeof(RookieShop.Storefront.SlugifyParameterTransformer));

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
    options.Conventions.Add(new RouteTokenTransformerConvention(new RookieShop.Storefront.SlugifyParameterTransformer()));
});

builder.Services.AddProgressiveWebApp();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseWebOptimizer();

app.UseMiddleware<CustomerInfoMiddleware>();

app.MapHealthCheck();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.UseStatusCodePages();

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
    "Basket",
    "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();