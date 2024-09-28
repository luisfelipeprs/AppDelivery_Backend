namespace AppDelivery.Domain.Repositories.Consumidor;
public interface IConsumidorReadOnlyRepository
{
    public Task<bool> ExistActiveConsumidorWithEmail(string email);
    public Task<List<Entities.Consumidor>> GetConsumidores();
    Task<Entities.Consumidor?> GetConsumidorById(long Id);
}
