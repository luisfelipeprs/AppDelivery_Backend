using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Consumer;
public interface IRegisterConsumerUseCase
{
    public Task<ResponseRegisteredConsumerJson> Execute(RequestRegisterConsumerJson request);
}