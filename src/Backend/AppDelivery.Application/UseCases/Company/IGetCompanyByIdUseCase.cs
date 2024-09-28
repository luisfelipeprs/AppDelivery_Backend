namespace AppDelivery.Application.UseCases.Company;
public interface IGetCompanyByIdUseCase
{
    Task<Domain.Entities.Company> Execute(long id);
}
