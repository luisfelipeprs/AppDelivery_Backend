namespace AppDelivery.Domain.Repositories.Review;
public interface IReviewWriteOnlyRepository
{
    public Task Add(Entities.Review review);
    Task<bool> Delete(Guid id);
}
