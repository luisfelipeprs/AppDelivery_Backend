using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.Driver;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class DriverRepository : IDriverWriteOnlyRepository, IDriverReadOnlyRepository, IDriverUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public DriverRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Driver driver)
    {
        await _dbContext.Drivers.AddAsync(driver);
    }

    public async Task<List<Driver>> GetDrivers()
    {
        return await _dbContext.Drivers.ToListAsync();
    }

    public async Task<Driver?> GetDriverById(Guid idDriver)
    {
        return await _dbContext.Drivers.AsNoTracking().FirstOrDefaultAsync(d => d.Id == idDriver);
    }

    public async Task<bool> Delete(Guid id)
    {
        var driver = await _dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        if (driver == null)
            return false;

        _dbContext.Drivers.Remove(driver);
        return true;
    }

    public void Update(Driver driver)
    {
        _dbContext.Drivers.Update(driver);
    }

    async Task<Driver?> IDriverUpdateOnlyRepository.GetById(Guid id)
    {
        return await _dbContext.Drivers.FirstOrDefaultAsync(d => d.Id == id);
    }

    public Task<bool> ExistActiveDriverWithEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<Driver?> GetDriverByEmail(string email)
    {
        var driver = await _dbContext.Drivers
            .FirstOrDefaultAsync(c => c.Email == email);

        return driver;
    }
}