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
            .ForMember(dest => dest.Password, opt => opt.Ignore()) // Ignora a senha se necessário
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // Caso queira ignorar o Id do User, pois pode ser gerado pelo banco de dados
    }

    private void DomainToResponse()
    {

    }
}
