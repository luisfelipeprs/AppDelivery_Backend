using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Order
{
    public interface IRegisterOrderUseCase
    {
        public Task<ResponseRegisteredOrderJson> Execute(RequestRegisterOrderJson request);
    }
}
