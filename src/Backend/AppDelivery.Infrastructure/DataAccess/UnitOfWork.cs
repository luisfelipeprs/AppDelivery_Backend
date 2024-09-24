using AppDelivery.Domain.Repositories;

namespace AppDelivery.Infrastructure.DataAccess;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDeliveryDbContext _dbContext;

    public UnitOfWork(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
