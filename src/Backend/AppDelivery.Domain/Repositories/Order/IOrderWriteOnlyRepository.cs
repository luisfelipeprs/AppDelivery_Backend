namespace AppDelivery.Domain.Repositories.Order;
public interface IOrderWriteOnlyRepository
{
    public Task Add(Entities.Order order);
    Task<bool> Delete(Guid id);
}
