using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Company
{
    public interface IGetCompanyUseCase
    {
        public Task<ResponseCompaniesJson> GetCompanies();
    }
}
