using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Company;
public interface ILoginCompanyUseCase
{
    public Task<(ResponseLoginCompanyJson?, string)> Login(RequestLoginCompanyJson request);
}