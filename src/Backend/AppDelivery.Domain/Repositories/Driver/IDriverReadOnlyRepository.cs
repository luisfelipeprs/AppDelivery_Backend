namespace AppDelivery.Domain.Repositories.Driver;
public interface IDriverReadOnlyRepository
{
    public Task<bool> ExistActiveDriverWithEmail(string email);
    public Task<List<Entities.Driver>> GetDrivers();
    Task<Entities.Driver?> GetDriverById(long Id);
}
