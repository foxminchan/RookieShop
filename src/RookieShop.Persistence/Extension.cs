using Ardalis.GuardClauses;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RookieShop.Domain.SharedKernel;
using RookieShop.Persistence.CompiledModels;
using RookieShop.Persistence.Interceptors;

namespace RookieShop.Persistence;

public static class Extension
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Postgres");

        Guard.Against.Null(connectionString, message: "Connection string 'Postgres' not found.");

        builder.Services.AddSingleton<AuditableEntityInterceptor>();

        builder.Services.AddSingleton<IDatabaseFactory, DatabaseFactory>();

        builder.Services.AddDbContextPool<ApplicationDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString, optionsBuilder =>
                {
                    optionsBuilder.MigrationsAssembly(AssemblyReference.DbContextAssembly.FullName);
                    optionsBuilder.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                })
                .UseExceptionProcessor()
                .UseSnakeCaseNamingConvention()
                .UseModel(ApplicationDbContextModel.Instance)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            options.AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>());

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                options
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
        }).AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddScoped<IDatabaseFacade>(p => p.GetRequiredService<ApplicationDbContext>());
        builder.Services.AddScoped<IDomainEventContext>(p => p.GetRequiredService<ApplicationDbContext>());
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return builder;
    }
}