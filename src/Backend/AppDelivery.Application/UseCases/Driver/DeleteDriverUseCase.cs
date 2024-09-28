using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Driver;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.Driver;
public class DeleteDriverUseCase : IDeleteDriverUseCase
{
    private readonly IDriverWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDriverUseCase(IDriverWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false) throw new NotFoundException("Entregador não encontrado.");

        await _unitOfWork.Commit();
    }
}
