using Ardalis.ListStartupServices;
using RookieShop.ApiService.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.ConfigureHttpClientDefaults(http => http.AddStandardResilienceHandler());

builder.Services.Configure<ServiceConfig>(config => config.Services = [.. builder.Services]);

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

app.UseHttpsRedirection();

app.Run();
