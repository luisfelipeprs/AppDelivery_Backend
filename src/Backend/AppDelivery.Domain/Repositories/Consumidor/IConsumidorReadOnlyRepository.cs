namespace AppDelivery.Domain.Repositories.Consumer;
public interface IConsumerReadOnlyRepository
{
    public Task<bool> ExistActiveConsumerWithEmail(string email);
    public Task<List<Entities.Consumer>> GetConsumers();
    Task<Entities.Consumer?> GetConsumerById(long Id);
}
