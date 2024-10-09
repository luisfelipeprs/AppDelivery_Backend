namespace AppDelivery.Domain.Repositories.Order;
public interface IOrderUpdateOnlyRepository
{
    void Update(Entities.Order order);
    Task<Entities.Order?> GetById(Guid id);
}
