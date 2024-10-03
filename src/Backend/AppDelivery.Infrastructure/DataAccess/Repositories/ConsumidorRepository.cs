using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.Consumer;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class ConsumerRepository : IConsumerWriteOnlyRepository, IConsumerReadOnlyRepository, IConsumerUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public ConsumerRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Consumer consumer)
    {
        await _dbContext.Consumers.AddAsync(consumer);
    }

    public async Task<List<Consumer>> GetConsumers()
    {
        return await _dbContext.Consumers.ToListAsync();
    }

    public async Task<Consumer?> GetConsumerById(long idConsumer)
    {
        return await _dbContext.Consumers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == idConsumer);
    }

    public async Task<bool> Delete(long id)
    {
        var consumer = await _dbContext.Consumers.FirstOrDefaultAsync(c => c.Id == id);
        if (consumer == null)
            return false;

        _dbContext.Consumers.Remove(consumer);
        return true;
    }

    public void Update(Consumer consumer)
    {
        _dbContext.Consumers.Update(consumer);
    }

    async Task<Consumer?> IConsumerUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Consumers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<bool> ExistActiveConsumerWithEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<Consumer?> GetByEmail(string email)
    {
        var consumer = await _dbContext.Consumers
            .FirstOrDefaultAsync(c => c.Email == email);

        return consumer;
    }
}