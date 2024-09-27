using AppDelivery.Application.Services.AutoMapper;
using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Application.UseCases;
using AppDelivery.Application.UseCases.User;
using AppDelivery.Domain.Repositories.User;
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
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
        services.AddScoped<IGetUserByIdUseCase, GetUsersUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
    }

    private static void AddPasswordEncrypter(IServiceCollection services)
    {
        services.AddScoped(options => new PasswordEncripter());
    }
}
