using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public UserRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);

        // await _dbContext.SaveChangesAsync(); IUnitOfWork já faz isso
    }
    public async Task<List<User>> GetUsers() {
        return await _dbContext.Users.ToListAsync();
    }
    public async Task<User?> GetUserById(long idUser)
    {
        return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == idUser);
    }


    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
    }

    public async Task<bool> Delete(long id)
    {
        var patient = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id);
        if (patient == null)
            return false;

        _dbContext.Users.Remove(patient);
        return true;
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }

    async Task<Domain.Entities.User?> IUserUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}
