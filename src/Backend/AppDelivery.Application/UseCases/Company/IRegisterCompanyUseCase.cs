using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Consumer;
public interface IRegisterCompanyUseCase
{
    public Task<ResponseRegisteredCompanyJson> Execute(RequestRegisterCompanyJson request);
}