using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Company;
using AppDelivery.Domain.Repositories.Consumer;
using AppDelivery.Domain.Repositories.Delivery;
using AppDelivery.Domain.Repositories.Driver;
using AppDelivery.Domain.Repositories.Order;
using AppDelivery.Domain.Repositories.Review;
using AppDelivery.Domain.Repositories.User;
using AppDelivery.Infrastructure.DataAccess;
using AppDelivery.Infrastructure.DataAccess.Repositories;
using AppDelivery.Infrastructure.Extensions;
using FluentMigrator.Runner;
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

        services.AddScoped<IConsumerWriteOnlyRepository, ConsumerRepository>();
        services.AddScoped<IConsumerReadOnlyRepository, ConsumerRepository>();
        services.AddScoped<IConsumerUpdateOnlyRepository, ConsumerRepository>();

        services.AddScoped<ICompanyWriteOnlyRepository, CompanyRepository>();
        services.AddScoped<ICompanyReadOnlyRepository, CompanyRepository>();
        services.AddScoped<ICompanyUpdateOnlyRepository, CompanyRepository>();

        services.AddScoped<IDriverWriteOnlyRepository, DriverRepository>();
        services.AddScoped<IDriverReadOnlyRepository, DriverRepository>();
        services.AddScoped<IDriverUpdateOnlyRepository, DriverRepository>();

        services.AddScoped<IOrderWriteOnlyRepository, OrderRepository>();
        services.AddScoped<IOrderReadOnlyRepository, OrderRepository>();
        services.AddScoped<IOrderUpdateOnlyRepository, OrderRepository>(); 
        
        services.AddScoped<IReviewWriteOnlyRepository, ReviewRepository>();
        services.AddScoped<IReviewReadOnlyRepository, ReviewRepository>();
        services.AddScoped<IReviewUpdateOnlyRepository, ReviewRepository>(); 
        
        services.AddScoped<IDeliveryWriteOnlyRepository, DeliveryRepository>();
        services.AddScoped<IDeliveryReadOnlyRepository, DeliveryRepository>();
        services.AddScoped<IDeliveryUpdateOnlyRepository, DeliveryRepository>();
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
