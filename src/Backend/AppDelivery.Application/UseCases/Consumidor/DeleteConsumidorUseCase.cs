using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Consumer;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.Consumer;
public class DeleteConsumerUseCase : IDeleteConsumerUseCase
{
    private readonly IConsumerWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteConsumerUseCase(IConsumerWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException("Consumer não encontrado.");
        }

        await _unitOfWork.Commit();
    }
}
