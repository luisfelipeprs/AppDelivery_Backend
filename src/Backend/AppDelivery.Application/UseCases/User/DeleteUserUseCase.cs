using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.User;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.User;
public class DeleteUserUseCase : IDeleteUserUseCase
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserUseCase(IUserWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);

        if (result == false)
        {
            throw new NotFoundException("User not found.");
        }

        await _unitOfWork.Commit();
    }
}
