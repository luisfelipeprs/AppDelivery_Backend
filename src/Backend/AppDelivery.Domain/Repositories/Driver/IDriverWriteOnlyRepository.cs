namespace AppDelivery.Domain.Repositories.Driver;
public interface IDriverWriteOnlyRepository
{
    public Task Add(Entities.Driver driver);
    Task<bool> Delete(Guid id);
}
