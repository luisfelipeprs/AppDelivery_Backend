namespace AppDelivery.Application.UseCases.Consumidor;


public interface IGetConsumidorUseCase
{
    public Task<List<Domain.Entities.Consumidor>> GetConsumidores();
    //Task<Domain.Entities.User> GetUserById(long id);
}