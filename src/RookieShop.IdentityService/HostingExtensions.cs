using Duende.IdentityServer;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RookieShop.IdentityService.Data;
using RookieShop.IdentityService.Data.CompiledModels;
using RookieShop.IdentityService.Models;
using RookieShop.IdentityService.Options;
using RookieShop.Infrastructure.DataProtection;
using RookieShop.Infrastructure.OpenTelemetry;
using Serilog;

namespace RookieShop.IdentityService;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var appSettings = new AppSettings();

        builder.Configuration.Bind(appSettings);

        builder.AddRedisDataProtection();

        builder.ConfigureOpenTelemetry();

        builder.Services.AddRazorPages();

        builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
            options
                .UseNpgsql(builder.Configuration.GetConnectionString("Postgres"))
                .UseExceptionProcessor()
                .UseModel(ApplicationDbContextModel.Instance)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        var identityServerBuilder = builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.ApiResources)
            .AddInMemoryClients(Config.Clients(appSettings.Client))
            .AddAspNetIdentity<ApplicationUser>();

        // not recommended for production - you need to store your key material somewhere secure
        if (builder.Environment.IsDevelopment()) identityServerBuilder.AddDeveloperSigningCredential();

        builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to https://localhost:5001/signin-google
                options.ClientId = appSettings.Provider.Google.ClientId;
                options.ClientSecret = appSettings.Provider.Google.ClientSecret;
            });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();

        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}