using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.User;
public interface IRegisterUserUseCase
{
   public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
