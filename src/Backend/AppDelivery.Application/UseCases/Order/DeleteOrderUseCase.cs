using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Order;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.Order;
public class DeleteOrderUseCase : IDeleteOrderUseCase
{
    private readonly IOrderWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderUseCase(IOrderWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false) throw new NotFoundException("Pedido não encontrado.");

        await _unitOfWork.Commit();
    }
}
