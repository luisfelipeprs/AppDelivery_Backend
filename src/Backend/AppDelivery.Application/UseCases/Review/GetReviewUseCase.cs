using AppDelivery.Domain.Repositories.Review;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Review;
public class GetReviewUseCase : IGetReviewUseCase, IGetReviewByIdUseCase
{
    private readonly IReviewReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;

    public GetReviewUseCase(
        IReviewReadOnlyRepository readOnlyRepository,
        IMapper mapper)
    {
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;

    }

    public async Task<List<Domain.Entities.Review>> GetReviews()
    {
        var review = await _readOnlyRepository.GetReviews();
        return review;
    }

    public async Task<Domain.Entities.Review> Execute(Guid Id)
    {
        var review = await _readOnlyRepository.GetReviewById(Id);

        return review!;
    }
}