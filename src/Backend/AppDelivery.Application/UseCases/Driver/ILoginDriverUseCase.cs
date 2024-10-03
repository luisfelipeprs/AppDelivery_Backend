using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Driver;
public interface ILoginDriverUseCase
{
    public Task<(ResponseLoginDriverJson?, string)> Login(RequestLoginDriverJson request);
}