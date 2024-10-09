using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Review;
using AppDelivery.Exception.ExceptionBase;

namespace AppDelivery.Application.UseCases.Review;
public class DeleteReviewUseCase : IDeleteReviewUseCase
{
    private readonly IReviewWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewUseCase(IReviewWriteOnlyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Guid id)
    {
        var result = await _repository.Delete(id);

        if (result == false) throw new NotFoundException("Review não encontrada.");

        await _unitOfWork.Commit();
    }
}
