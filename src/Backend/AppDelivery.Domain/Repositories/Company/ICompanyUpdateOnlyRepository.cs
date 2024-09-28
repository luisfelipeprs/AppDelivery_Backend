namespace AppDelivery.Domain.Repositories.Company;
public interface ICompanyUpdateOnlyRepository
{
    void Update(Entities.Company Company);
    Task<Entities.Company?> GetById(long id);
}
