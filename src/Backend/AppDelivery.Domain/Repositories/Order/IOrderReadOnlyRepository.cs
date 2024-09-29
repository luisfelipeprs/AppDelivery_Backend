namespace AppDelivery.Domain.Repositories.Order;
public interface IOrderReadOnlyRepository
{
    public Task<List<Entities.Order>> GetOrders();
    Task<Entities.Order?> GetOrderById(long Id);
}
