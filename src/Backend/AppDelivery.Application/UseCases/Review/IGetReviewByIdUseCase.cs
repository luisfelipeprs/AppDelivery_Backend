namespace AppDelivery.Application.UseCases.Review;

public interface IGetReviewByIdUseCase
{
    Task<Domain.Entities.Review> Execute(long id);
}
