namespace AppDelivery.Domain.Repositories.Delivery;
public interface IDeliveryWriteOnlyRepository
{
    public Task Add(Entities.Delivery delivery);
    Task<bool> Delete(Guid id);
}