using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Entities.User;
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
    }

    private void DomainToResponse()
    {

    }
}
