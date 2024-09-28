namespace AppDelivery.Application.UseCases.Company
{
    public interface IGetCompanyUseCase
    {
        public Task<List<Domain.Entities.Company>> GetCompanies();
    }
}
