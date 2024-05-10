using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Infrastructure.Endpoints.Abstractions;

namespace RookieShop.Infrastructure.Endpoints;

public static class Extension
{
    public static void AddEndpoints(this IHostApplicationBuilder builder, Type type) =>
        builder.Services.Scan(scan => scan
            .FromAssembliesOf(type)
            .AddClasses(classes => classes.AssignableTo<IEndpointBase>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());

    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        var scope = app.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetRequiredService<IEnumerable<IEndpointBase>>();

        var apiVersionSet = app
            .NewApiVersionSet()
            .HasApiVersion(new(1, 0))
            .HasApiVersion(new(2, 0))
            .ReportApiVersions()
            .Build();

        IEndpointRouteBuilder builder = app
            .MapGroup("/api/v{apiVersion:apiVersion}")
            .WithApiVersionSet(apiVersionSet);

        foreach (var endpoint in endpoints) endpoint.MapEndpoint(builder);

        return app;
    }
}