using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Delivery;
public interface IRegisterDeliveryUseCase
{
    public Task<ResponseRegisteredDeliveryJson> Execute(RequestRegisterDeliveryJson request);
}
