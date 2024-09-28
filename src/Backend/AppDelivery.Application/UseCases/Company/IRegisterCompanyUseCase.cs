using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Consumidor;
public interface IRegisterCompanyUseCase
{
    public Task<ResponseRegisteredCompanyJson> Execute(RequestRegisterCompanyJson request);
}