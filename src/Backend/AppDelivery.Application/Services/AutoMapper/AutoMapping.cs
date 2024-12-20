﻿using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Entities;
using AutoMapper;

namespace AppDelivery.Application.Services.AutoMapper;
internal class AutoMapping : Profile
{
    private TypeDriver MapDeliveryType(string? deliveryType)
    {
        if (string.IsNullOrWhiteSpace(deliveryType))
        {
            throw new ArgumentException("DeliveryType cannot be null or empty");
        }

        if (Enum.TryParse(deliveryType.Trim(), true, out TypeDriver parsedType))
        {
            return parsedType;
        }

        throw new ArgumentException($"Invalid DeliveryType: {deliveryType}");
    }


    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<RequestUserJson, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<RequestLoginConsumerJson, Consumer>();
        CreateMap<RequestRegisterConsumerJson, Consumer>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<RequestConsumerJson, Consumer>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<RequestLoginCompanyJson, Company>();
        CreateMap<RequestConfirmResetJson, Company>();
        CreateMap<RequestRegisterCompanyJson, Company>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<RequestCompanyJson, Company>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<RequestLoginDriverJson, Driver>();
        CreateMap<RequestRegisterDriverJson, Driver>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<RequestDriverJson, Driver>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<RequestRegisterOrderJson, Order>()
            .ForMember(dest => dest.OrderId, opt => opt.Ignore())
            .ForMember(dest => dest.Consumer, opt => opt.Ignore())
            .ForMember(dest => dest.Company, opt => opt.Ignore())
            .ForMember(dest => dest.Delivery, opt => opt.Ignore());

        CreateMap<RequestOrderJson, Order>()
            .ForMember(dest => dest.OrderId, opt => opt.Ignore())
            .ForMember(dest => dest.Consumer, opt => opt.Ignore())
            .ForMember(dest => dest.Company, opt => opt.Ignore())
            .ForMember(dest => dest.Delivery, opt => opt.Ignore());

        CreateMap<RequestReviewJson, Review>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Company, opt => opt.Ignore())
            .ForMember(dest => dest.Consumer, opt => opt.Ignore())
            .ForMember(dest => dest.Driver, opt => opt.Ignore());

        CreateMap<RequestReviewJson, Review>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Company, opt => opt.Ignore())
            .ForMember(dest => dest.Consumer, opt => opt.Ignore())
            .ForMember(dest => dest.Driver, opt => opt.Ignore());

        CreateMap<RequestRegisterDeliveryJson, Delivery>();

        CreateMap<RequestDeliveryJson, Delivery>();

        CreateMap<RequestResetPasswordJson, PasswordResetToken>();
        CreateMap<RequestResetPasswordJson, Company>();
        CreateMap<RequestResetPasswordJson, Consumer>();
        CreateMap<RequestResetPasswordJson, Driver>(); 
        
        CreateMap<RequestConfirmResetJson, PasswordResetToken>();
        CreateMap<RequestConfirmResetJson, Company>();
        CreateMap<RequestConfirmResetJson, Consumer>();
        CreateMap<RequestConfirmResetJson, Driver>();

        CreateMap<Company, ResponseShortCompanyJson>();
        CreateMap<Company, ResponseCompanyDataJson>();
        CreateMap<Consumer, ResponseConsumerDataJson>();
        CreateMap<Consumer, ResponseConsumerByIdJson>();
        CreateMap<Driver, ResponseDriversJson>();
        CreateMap<Driver, ResponseDriverDataJson>();
        CreateMap<Driver, ResponseDriverByIdJson>();
    }
    private void DomainToResponse()
    {

    }
}
