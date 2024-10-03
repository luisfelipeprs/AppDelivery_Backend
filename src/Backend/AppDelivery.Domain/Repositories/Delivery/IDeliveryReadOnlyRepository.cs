namespace AppDelivery.Domain.Repositories.Delivery;
public interface IDeliveryReadOnlyRepository
{
    public Task<bool> ExistActiveDeliveryWithEmail(string email);
    public Task<List<Entities.Delivery>> GetDeliveries();
    public Task<List<Entities.Delivery>> GetDeliveriesRecords();
    Task<Entities.Delivery?> GetDeliveryById(long Id);
}
