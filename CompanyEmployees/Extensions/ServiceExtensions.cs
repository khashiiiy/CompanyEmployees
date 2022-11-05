
using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

namespace CompanyEmployees.Extensions;

public static class ServiceExtensions
{
    public static void AddConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {   // Only for development environment, change the settings for production!!!
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

    public static void AddConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void AddRepositoryService(this IServiceCollection services)
        => services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static void ConfigureSqlContext(this IServiceCollection services)
    {
        services.AddDbContext<RepositoryContexts>(options =>
        {
            options.UseSqlite("Data Source=CompanyEmployee.db");
        });
    }
}