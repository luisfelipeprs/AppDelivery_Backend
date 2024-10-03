using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Consumer;
public interface ILoginConsumerUseCase
{
    public Task<(ResponseLoginConsumerJson?, string)> Login(RequestLoginConsumerJson request);
}