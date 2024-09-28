using AppDelivery.Application.Services.AutoMapper;
using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Application.UseCases;
using AppDelivery.Application.UseCases.Company;
using AppDelivery.Application.UseCases.Consumidor;
using AppDelivery.Application.UseCases.Driver;
using AppDelivery.Application.UseCases.User;
using Microsoft.Extensions.DependencyInjection;

namespace AppDelivery.Application;
public static class DependecyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddPasswordEncrypter(services);
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        // teste user base
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
        services.AddScoped<IGetUserByIdUseCase, GetUsersUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();

        // consumers
        services.AddScoped<IRegisterConsumidorUseCase, RegisterConsumidorUseCase>();
        services.AddScoped<IGetConsumidorUseCase, GetConsumidorUseCase>();
        services.AddScoped<IGetConsumidorByIdUseCase, GetConsumidorUseCase>();
        services.AddScoped<IUpdateConsumidorUseCase, UpdateConsumidorUseCase>();
        services.AddScoped<IDeleteConsumidorUseCase, DeleteConsumidorUseCase>();

        // company
        services.AddScoped<IRegisterCompanyUseCase, RegisterCompanyUseCase>();
        services.AddScoped<IGetCompanyUseCase, GetCompanyUseCase>();
        services.AddScoped<IGetCompanyByIdUseCase, GetCompanyUseCase>();
        services.AddScoped<IUpdateCompanyUseCase, UpdateCompanyUseCase>();
        services.AddScoped<IDeleteCompanyUseCase, DeleteCompanyUseCase>();

        // driverDriver
        services.AddScoped<IRegisterDriverUseCase, RegisterDriverUseCase>();
        services.AddScoped<IGetDriverUseCase, GetDriverUseCase>();
        services.AddScoped<IGetDriverByIdUseCase, GetDriverUseCase>();
        services.AddScoped<IUpdateDriverUseCase, UpdateDriverUseCase>();
        services.AddScoped<IDeleteDriverUseCase, DeleteDriverUseCase>();
    }

    private static void AddPasswordEncrypter(IServiceCollection services)
    {
        services.AddScoped(options => new PasswordEncripter());
    }
}
