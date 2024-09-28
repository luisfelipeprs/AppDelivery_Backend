using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Consumidor;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.Consumidor;
public class DeleteConsumidorUseCase : IDeleteConsumidorUseCase
{
    private readonly IConsumidorWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteConsumidorUseCase(IConsumidorWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException("Consumidor não encontrado.");
        }

        await _unitOfWork.Commit();
    }
}
