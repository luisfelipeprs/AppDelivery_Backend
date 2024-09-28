using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Company;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.Company;
public class DeleteCompanyUseCase : IDeleteCompanyUseCase
{
    private readonly ICompanyWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCompanyUseCase(ICompanyWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException("Empresa não encontrada.");
        }

        await _unitOfWork.Commit();
    }
}
