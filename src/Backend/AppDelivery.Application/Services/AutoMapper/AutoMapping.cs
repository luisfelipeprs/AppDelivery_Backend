using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Entities;
using AutoMapper;

namespace AppDelivery.Application.Services.AutoMapper;
internal class AutoMapping : Profile
{
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

        CreateMap<RequestRegisterConsumidorJson, Consumidor>()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<RequestConsumidorJson, Consumidor>()
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
    }
    private void DomainToResponse()
    {

    }
}
