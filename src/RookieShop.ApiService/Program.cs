using System.Text.Json;
using Ardalis.ListStartupServices;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using RookieShop.ApiService.Middlewares;
using RookieShop.Application;
using RookieShop.Infrastructure;
using RookieShop.Infrastructure.Endpoints;
using RookieShop.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(config => config.ValidateOnBuild = true);

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
    options.AllowResponseHeaderCompression = true;
    options.ConfigureEndpointDefaults(o => o.Protocols = HttpProtocols.Http1AndHttp2AndHttp3);
});

builder.Services
    .AddResponseCompression()
    .AddRouting(options => options.LowercaseUrls = true)
    .AddSingleton(new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    });

builder.Services.AddAntiforgery();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.Configure<ServiceConfig>(config => config.Services = [.. builder.Services]);

builder.AddInfrastructure().AddPersistence().AddApplication();

builder.AddEndpoints(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseShowAllServicesMiddleware();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseAntiforgery();

app.UseResponseCompression();

app.UseHttpsRedirection();

app.MapInfrastructure();

app.MapEndpoints();

app.Run();