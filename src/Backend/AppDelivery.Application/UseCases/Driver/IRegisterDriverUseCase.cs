using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Driver
{
    public interface IRegisterDriverUseCase
    {
        public Task<ResponseRegisteredDriverJson> Execute(RequestRegisterDriverJson request);
    }
}
