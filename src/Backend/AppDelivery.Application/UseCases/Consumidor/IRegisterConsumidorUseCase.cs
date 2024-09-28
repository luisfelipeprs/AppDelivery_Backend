using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Consumidor;
public interface IRegisterConsumidorUseCase
{
    public Task<ResponseRegisteredConsumidorJson> Execute(RequestRegisterConsumidorJson request);
}