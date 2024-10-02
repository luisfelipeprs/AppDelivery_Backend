using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.Order;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class OrderRepository : IOrderWriteOnlyRepository, IOrderReadOnlyRepository, IOrderUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public OrderRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _dbContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetOrderById(long idOrder)
    {
        return await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(d => d.OrderId == idOrder);
    }

    public async Task<bool> Delete(long id)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(d => d.OrderId == id);
        if (order == null)
            return false;

        _dbContext.Orders.Remove(order);
        return true;
    }

    public void Update(Order order)
    {
        _dbContext.Orders.Update(order);
    }

    async Task<Order?> IOrderUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Orders.FirstOrDefaultAsync(d => d.OrderId == id);
    }
}