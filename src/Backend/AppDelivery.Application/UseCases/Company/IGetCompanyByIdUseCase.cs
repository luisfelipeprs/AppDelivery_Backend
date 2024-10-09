using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Company;
public interface IGetCompanyByIdUseCase
{
    Task<ResponseCompanyJson> Execute(Guid id);
}
