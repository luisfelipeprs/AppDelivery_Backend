namespace AppDelivery.Domain.Repositories.Consumidor;
public interface IConsumidorUpdateOnlyRepository
{
    void Update(Entities.Consumidor consumidor);
    Task<Entities.Consumidor?> GetById(long id);
}
