namespace AppDelivery.Domain.Repositories.Order;
public interface IOrderReadOnlyRepository
{
    public Task<List<Entities.Order>> GetOrders();
    public Task<List<Entities.Order>> GetOrdersAvailable();

    Task<Entities.Order?> GetOrderById(long Id);
}
