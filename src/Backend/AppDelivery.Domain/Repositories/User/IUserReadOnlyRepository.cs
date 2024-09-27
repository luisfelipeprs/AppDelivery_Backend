namespace AppDelivery.Domain.Repositories.User;
public interface IUserReadOnlyRepository
{
    public Task<bool> ExistActiveUserWithEmail(string email);
    public Task<List<Entities.User>> GetUsers();
    Task<Entities.User?> GetUserById(long Id);
}
