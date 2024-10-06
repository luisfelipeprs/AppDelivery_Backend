using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Consumer;


public interface IGetConsumerUseCase
{
    public Task<ResponseConsumerJson> GetConsumers();
    //Task<Domain.Entities.User> GetUserById(long id);
}