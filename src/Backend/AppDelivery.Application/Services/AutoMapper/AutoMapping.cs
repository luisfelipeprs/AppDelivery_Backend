using AppDelivery.Communication.Requests;
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

        CreateMap<RequestRegisterConsumerJson, Consumer>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<RequestConsumerJson, Consumer>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<RequestRegisterCompanyJson, Company>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<RequestCompanyJson, Company>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<RequestRegisterDriverJson, Driver>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<RequestDriverJson, Driver>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<RequestRegisterOrderJson, Order>()
            .ForMember(dest => dest.OrderId, opt => opt.Ignore())
            .ForMember(dest => dest.Consumer, opt => opt.Ignore())
            .ForMember(dest => dest.Company, opt => opt.Ignore())
            .ForMember(dest => dest.Delivery, opt => opt.Ignore())
            .ForMember(dest => dest.DeliveryType, opt => opt.MapFrom(src => MapDeliveryType(src.DeliveryType)));

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
    }
    private void DomainToResponse()
    {

    }
}
