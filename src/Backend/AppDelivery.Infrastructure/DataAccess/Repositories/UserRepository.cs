using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public UserRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);

        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
    }
}
