var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpClientDefaults(http => http.AddStandardResilienceHandler());

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
