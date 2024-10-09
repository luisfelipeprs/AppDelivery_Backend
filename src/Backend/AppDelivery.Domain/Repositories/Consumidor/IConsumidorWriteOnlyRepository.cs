namespace AppDelivery.Domain.Repositories.Consumer;
public interface IConsumerWriteOnlyRepository
{
    public Task Add(Entities.Consumer consumer);
    Task<bool> Delete(Guid id);
}
