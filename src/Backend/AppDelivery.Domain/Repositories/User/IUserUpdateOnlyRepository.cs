namespace AppDelivery.Domain.Repositories.User;
public interface IUserUpdateOnlyRepository
{
    void Update(Entities.User User);
    Task<Entities.User?> GetById(long id);
}
