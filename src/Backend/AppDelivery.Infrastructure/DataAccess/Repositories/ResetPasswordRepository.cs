using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.ResetPassword;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class ResetPasswordRepository : IResetPasswordWriteOnlyRepository, IResetPasswordReadOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public ResetPasswordRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Delete(long id)
    {
        var resetpassword = await _dbContext.PasswordResetToken.FirstOrDefaultAsync(d => d.Id == id);
        if (resetpassword == null)
            return false;

        _dbContext.PasswordResetToken.Remove(resetpassword);
        return true;
    }

    public async Task AddToken(PasswordResetToken token)
    {
        await _dbContext.PasswordResetToken.AddAsync(token);
    }

    public async Task<PasswordResetToken?> GetToken(string token)
    {
        var Entitytoken = await _dbContext.PasswordResetToken.FirstOrDefaultAsync(e => e.ResetToken == token);
        return Entitytoken;
    }   
}