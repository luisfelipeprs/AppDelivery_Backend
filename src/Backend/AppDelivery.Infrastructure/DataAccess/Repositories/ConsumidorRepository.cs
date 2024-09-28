using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.Consumidor;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class ConsumidorRepository : IConsumidorWriteOnlyRepository, IConsumidorReadOnlyRepository, IConsumidorUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public ConsumidorRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Consumidor consumidor)
    {
        await _dbContext.Consumidores.AddAsync(consumidor);
    }

    public async Task<List<Consumidor>> GetConsumidores()
    {
        return await _dbContext.Consumidores.ToListAsync();
    }

    public async Task<Consumidor?> GetConsumidorById(long idConsumidor)
    {
        return await _dbContext.Consumidores.AsNoTracking().FirstOrDefaultAsync(c => c.Id == idConsumidor);
    }

    public async Task<bool> Delete(long id)
    {
        var consumidor = await _dbContext.Consumidores.FirstOrDefaultAsync(c => c.Id == id);
        if (consumidor == null)
            return false;

        _dbContext.Consumidores.Remove(consumidor);
        return true;
    }

    public void Update(Consumidor consumidor)
    {
        _dbContext.Consumidores.Update(consumidor);
    }

    async Task<Consumidor?> IConsumidorUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Consumidores.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<bool> ExistActiveConsumidorWithEmail(string email)
    {
        throw new NotImplementedException();
    }
}