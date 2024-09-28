namespace AppDelivery.Domain.Repositories.Consumidor;
public interface IConsumidorWriteOnlyRepository
{
    public Task Add(Entities.Consumidor consumidor);
    Task<bool> Delete(long id);
}
