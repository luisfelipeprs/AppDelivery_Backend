namespace AppDelivery.Application.UseCases.Consumer;


public interface IGetConsumerUseCase
{
    public Task<List<Domain.Entities.Consumer>> GetConsumers();
    //Task<Domain.Entities.User> GetUserById(long id);
}