namespace AppDelivery.Domain.Repositories;
public interface IUnitOfWork
{
    public Task Commit();
}
