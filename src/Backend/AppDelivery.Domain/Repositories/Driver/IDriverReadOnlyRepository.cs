namespace AppDelivery.Domain.Repositories.Driver;
public interface IDriverReadOnlyRepository
{
    public Task<bool> ExistActiveDriverWithEmail(string email);
    public Task<List<Entities.Driver>> GetDrivers();
    public Task<Entities.Driver?> GetDriverByEmail(string email);
    Task<Entities.Driver?> GetDriverById(long Id);
}
