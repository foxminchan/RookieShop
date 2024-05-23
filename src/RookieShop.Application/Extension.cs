using System.Diagnostics;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Application.Orders.Services;
using RookieShop.Application.Orders.Worker;
using RookieShop.Application.Products.Services;
using RookieShop.Application.Products.Workers;
using RookieShop.Infrastructure.Logging;
using RookieShop.Infrastructure.Validator;
using RookieShop.Persistence;

namespace RookieShop.Application;

public static class Extension
{
    [DebuggerStepThrough]
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        var assemblies = new[]
        {
            AssemblyReference.Executing,
            Persistence.AssemblyReference.Executing,
            Domain.AssemblyReference.Executing
        };

        builder.Services.AddValidatorsFromAssemblies([AssemblyReference.Executing]);

        builder.Services.AddHttpContextAccessor()
            .AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(assemblies);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>),
                    ServiceLifetime.Scoped);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TxBehavior<,>),
                    ServiceLifetime.Scoped);
            });

        builder.Services.AddScoped<IOrderService, OrderService>();

        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddHostedService<CalculateRatingWorker>();

        builder.Services.AddHostedService<SendEmailWorker>();

        return builder;
    }
}