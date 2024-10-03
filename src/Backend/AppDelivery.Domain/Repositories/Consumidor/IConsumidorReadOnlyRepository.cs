namespace AppDelivery.Domain.Repositories.Consumer;
public interface IConsumerReadOnlyRepository
{
    public Task<bool> ExistActiveConsumerWithEmail(string email);
    public Task<List<Entities.Consumer>> GetConsumers();
    public Task<Entities.Consumer?> GetByEmail(string email);
    Task<Entities.Consumer?> GetConsumerById(long Id);
}
