namespace AppDelivery.Domain.Repositories.Driver;
public interface IDriverUpdateOnlyRepository
{
    void Update(Entities.Driver driver);
    Task<Entities.Driver?> GetById(long id);
}
