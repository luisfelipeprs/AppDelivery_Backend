namespace AppDelivery.Domain.Repositories.Review;
public interface IReviewReadOnlyRepository
{
    public Task<List<Entities.Review>> GetReviews();
    Task<Entities.Review?> GetReviewById(long Id);
}
