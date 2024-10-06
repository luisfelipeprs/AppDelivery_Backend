using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Consumer;
public interface IGetConsumerByIdUseCase
{
    Task<ResponseConsumerByIdJson> Execute(long id);
}
