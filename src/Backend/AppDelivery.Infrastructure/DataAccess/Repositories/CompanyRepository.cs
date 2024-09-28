using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.Company;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class CompanyRepository : ICompanyWriteOnlyRepository, ICompanyReadOnlyRepository, ICompanyUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public CompanyRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Company company)
    {
        await _dbContext.Companies.AddAsync(company);
    }

    public async Task<List<Company>> GetCompanies()
    {
        return await _dbContext.Companies.ToListAsync();
    }

    public async Task<Company?> GetCompanyById(long idCompany)
    {
        return await _dbContext.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == idCompany);
    }

    public async Task<bool> Delete(long id)
    {
        var company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
        if (company == null) return false;

        _dbContext.Companies.Remove(company);
        return true;
    }

    public void Update(Company company)
    {
        _dbContext.Companies.Update(company);
    }

    async Task<Company?> ICompanyUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.Companies.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<bool> ExistActiveCompanyWithEmail(string email)
    {
        throw new NotImplementedException();
    }
}