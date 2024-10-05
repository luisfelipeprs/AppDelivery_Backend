namespace AppDelivery.Domain.Repositories.Company;
public interface ICompanyReadOnlyRepository
{
    public Task<bool> ExistActiveCompanyWithEmail(string email);
    public Task<Entities.Company?> GetCompanyByEmail(string email);
    public Task<List<Entities.Company>> GetCompanies();
    Task<Entities.Company?> GetCompanyById(long Id);
}
