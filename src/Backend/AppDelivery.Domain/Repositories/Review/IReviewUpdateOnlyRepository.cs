namespace AppDelivery.Domain.Repositories.Review;
public interface IReviewUpdateOnlyRepository
{
    void Update(Entities.Review review);
    Task<Entities.Review?> GetById(Guid id);
}
