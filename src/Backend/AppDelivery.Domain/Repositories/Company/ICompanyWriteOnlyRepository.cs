namespace AppDelivery.Domain.Repositories.Company;
public interface ICompanyWriteOnlyRepository
{
    public Task Add(Entities.Company company);
    Task<bool> Delete(Guid id);
}