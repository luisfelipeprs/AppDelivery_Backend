
namespace AppDelivery.Application.UseCases.Review
{
    public interface IGetReviewUseCase
    {
        public Task<List<Domain.Entities.Review>> GetReviews();
    }
}
