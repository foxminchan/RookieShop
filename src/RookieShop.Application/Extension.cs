using System.Diagnostics;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieShop.Application.Orders.Workers;
using RookieShop.Application.Products.Workers;
using RookieShop.Infrastructure.Cache;
using RookieShop.Infrastructure.Logging;
using RookieShop.Infrastructure.Metrics;
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
                cfg.AddOpenBehavior(typeof(QueryCachingBehavior<,>));
                cfg.AddOpenBehavior(typeof(MetricsBehavior<,>));
            });

        builder.Services.AddHostedService<CalculateRatingWorker>();

        builder.Services.AddHostedService<SendEmailWorker>();

        return builder;
    }
}