namespace AppDelivery.Domain.Repositories.Delivery;
public interface IDeliveryUpdateOnlyRepository
{
    void Update(Entities.Delivery delivery);
    Task<Entities.Delivery?> GetById(Guid id);
}
