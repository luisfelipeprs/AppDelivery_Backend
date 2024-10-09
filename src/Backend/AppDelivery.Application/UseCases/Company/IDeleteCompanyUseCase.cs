namespace AppDelivery.Application.UseCases.Company;
public interface IDeleteCompanyUseCase
{
    Task Execute(Guid id);
}