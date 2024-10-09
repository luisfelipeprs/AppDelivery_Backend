using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.Delivery;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class DeliveryRepository : IDeliveryWriteOnlyRepository, IDeliveryReadOnlyRepository, IDeliveryUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public DeliveryRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Delivery delivery)
    {
        await _dbContext.Deliveries.AddAsync(delivery);
    }

    public async Task<List<Delivery>> GetDeliveries()
    {
        return await _dbContext.Deliveries.ToListAsync();
    }

    public async Task<Delivery?> GetDeliveryById(Guid idDelivery)
    {
        return await _dbContext.Deliveries.AsNoTracking().FirstOrDefaultAsync(c => c.DeliveryId == idDelivery);
    }

    public async Task<bool> Delete(Guid id)
    {
        var delivery = await _dbContext.Deliveries.FirstOrDefaultAsync(c => c.DeliveryId == id);
        if (delivery == null)
            return false;

        _dbContext.Deliveries.Remove(delivery);
        return true;
    }

    public void Update(Delivery delivery)
    {
        _dbContext.Deliveries.Update(delivery);
    }

    async Task<Delivery?> IDeliveryUpdateOnlyRepository.GetById(Guid id)
    {
        return await _dbContext.Deliveries.FirstOrDefaultAsync(c => c.DeliveryId == id);
    }

    public Task<bool> ExistActiveDeliveryWithEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Delivery>> GetDeliveriesRecords() => await _dbContext.Deliveries.Where(d => d.Status != DeliveryStatus.InTransit && d.Status != DeliveryStatus.NotStarted).ToListAsync();
}