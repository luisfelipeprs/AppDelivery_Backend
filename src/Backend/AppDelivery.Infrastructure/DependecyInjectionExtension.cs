using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.User;
using AppDelivery.Infrastructure.DataAccess;
using AppDelivery.Infrastructure.DataAccess.Repositories;
using FluentMigrator.Runner;
using AppDelivery.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AppDelivery.Infrastructure;
public static class DependecyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext_MySql(services, configuration);
        // AddFluentMigrator_MySql(services, configuration);
    }

    private static void AddDbContext_MySql(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 35));

        services.AddDbContext<AppDeliveryDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseMySql(connectionString, serverVersion);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
    }
    private static void AddFluentMigrator_MySql(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();

        services.AddFluentMigratorCore().ConfigureRunner(options =>
        {
            options
            .AddMySql8()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(Assembly.Load("AppDelivery.Infrastructure")).For.All();
        }
        );
    }
}
