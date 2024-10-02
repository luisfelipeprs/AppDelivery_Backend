using AppDelivery.Application.Services.AutoMapper;
using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Application.UseCases;
using AppDelivery.Application.UseCases.Company;
using AppDelivery.Application.UseCases.Consumer;
using AppDelivery.Application.UseCases.Delivery;
using AppDelivery.Application.UseCases.Driver;
using AppDelivery.Application.UseCases.Order;
using AppDelivery.Application.UseCases.Review;
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
        services.AddScoped<IRegisterConsumerUseCase, RegisterConsumerUseCase>();
        services.AddScoped<IGetConsumerUseCase, GetConsumerUseCase>();
        services.AddScoped<IGetConsumerByIdUseCase, GetConsumerUseCase>();
        services.AddScoped<IUpdateConsumerUseCase, UpdateConsumerUseCase>();
        services.AddScoped<IDeleteConsumerUseCase, DeleteConsumerUseCase>();

        // company
        services.AddScoped<IRegisterCompanyUseCase, RegisterCompanyUseCase>();
        services.AddScoped<IGetCompanyUseCase, GetCompanyUseCase>();
        services.AddScoped<IGetCompanyByIdUseCase, GetCompanyUseCase>();
        services.AddScoped<IUpdateCompanyUseCase, UpdateCompanyUseCase>();
        services.AddScoped<IDeleteCompanyUseCase, DeleteCompanyUseCase>();

        // driver
        services.AddScoped<IRegisterDriverUseCase, RegisterDriverUseCase>();
        services.AddScoped<IGetDriverUseCase, GetDriverUseCase>();
        services.AddScoped<IGetDriverByIdUseCase, GetDriverUseCase>();
        services.AddScoped<IUpdateDriverUseCase, UpdateDriverUseCase>();
        services.AddScoped<IDeleteDriverUseCase, DeleteDriverUseCase>();


        // order
        services.AddScoped<IRegisterOrderUseCase, RegisterOrderUseCase>();
        services.AddScoped<IGetOrderUseCase, GetOrderUseCase>();
        services.AddScoped<IGetOrderByIdUseCase, GetOrderUseCase>();
        services.AddScoped<IUpdateOrderUseCase, UpdateOrderUseCase>();
        services.AddScoped<IDeleteOrderUseCase, DeleteOrderUseCase>();

        // review
        services.AddScoped<IRegisterReviewUseCase, RegisterReviewUseCase>();
        services.AddScoped<IGetReviewUseCase, GetReviewUseCase>();
        services.AddScoped<IGetReviewByIdUseCase, GetReviewUseCase>();
        services.AddScoped<IUpdateReviewUseCase, UpdateReviewUseCase>();
        services.AddScoped<IDeleteReviewUseCase, DeleteReviewUseCase>();        

        // delivery
        services.AddScoped<IRegisterDeliveryUseCase, RegisterDeliveryUseCase>();
        services.AddScoped<IGetDeliveryUseCase, GetDeliveryUseCase>();
        services.AddScoped<IGetDeliveryByIdUseCase, GetDeliveryUseCase>();
        services.AddScoped<IUpdateDeliveryUseCase, UpdateDeliveryUseCase>();
        services.AddScoped<IDeleteDeliveryUseCase, DeleteDeliveryUseCase>();
    }

    private static void AddPasswordEncrypter(IServiceCollection services)
    {
        services.AddScoped(options => new PasswordEncripter());
    }
}
