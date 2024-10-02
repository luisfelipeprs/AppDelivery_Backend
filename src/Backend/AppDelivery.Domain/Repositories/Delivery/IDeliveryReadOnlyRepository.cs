namespace AppDelivery.Domain.Repositories.Delivery;
public interface IDeliveryReadOnlyRepository
{
    public Task<bool> ExistActiveDeliveryWithEmail(string email);
    public Task<List<Entities.Delivery>> GetDeliveries();
    Task<Entities.Delivery?> GetDeliveryById(long Id);
}
