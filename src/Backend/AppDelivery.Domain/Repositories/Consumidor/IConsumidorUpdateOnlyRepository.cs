namespace AppDelivery.Domain.Repositories.Consumer;
public interface IConsumerUpdateOnlyRepository
{
    void Update(Entities.Consumer consumer);
    Task<Entities.Consumer?> GetById(Guid id);
}
