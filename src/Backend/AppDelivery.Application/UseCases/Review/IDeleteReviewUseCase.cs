namespace AppDelivery.Application.UseCases.Review;
public interface IDeleteReviewUseCase
{
    Task Execute(long id);
}
