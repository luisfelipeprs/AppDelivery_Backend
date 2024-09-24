using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.User;
using AppDelivery.Infrastructure.DataAccess;
using AppDelivery.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppDelivery.Infrastructure;
public static class DependecyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext_MySql(services, configuration);
        AddRepositories(services);
    }

    private static void AddDbContext_MySql(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionMySql");
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
    }
}
