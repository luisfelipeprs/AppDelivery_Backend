using AppDelivery.Domain.Entities;
using AppDelivery.Domain.Repositories.Review;
using Microsoft.EntityFrameworkCore;

namespace AppDelivery.Infrastructure.DataAccess.Repositories;
public class ReviewRepository : IReviewWriteOnlyRepository, IReviewReadOnlyRepository, IReviewUpdateOnlyRepository
{
    private readonly AppDeliveryDbContext _dbContext;

    public ReviewRepository(AppDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Review review)
    {
        await _dbContext.Reviews.AddAsync(review);
    }

    public async Task<List<Review>> GetReviews()
    {
        return await _dbContext.Reviews.ToListAsync();
    }

    public async Task<Review?> GetReviewById(Guid idReview)
    {
        return await _dbContext.Reviews.AsNoTracking().FirstOrDefaultAsync(d => d.Id == idReview);
    }

    public async Task<bool> Delete(Guid id)
    {
        var review = await _dbContext.Reviews.FirstOrDefaultAsync(d => d.Id == id);
        if (review == null)
            return false;

        _dbContext.Reviews.Remove(review);
        return true;
    }

    public void Update(Review review)
    {
        _dbContext.Reviews.Update(review);
    }

    async Task<Review?> IReviewUpdateOnlyRepository.GetById(Guid id)
    {
        return await _dbContext.Reviews.FirstOrDefaultAsync(d => d.Id == id);
    }
}