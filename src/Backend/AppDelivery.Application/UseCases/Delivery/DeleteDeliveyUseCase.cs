using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Delivery;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.Delivery;
public class DeleteDeliveryUseCase : IDeleteDeliveryUseCase
{
    private readonly IDeliveryWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDeliveryUseCase(IDeliveryWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var result = await _repository.Delete(id);

        if (result == false) throw new NotFoundException("Pedido não encontrado.");

        await _unitOfWork.Commit();
    }
}
