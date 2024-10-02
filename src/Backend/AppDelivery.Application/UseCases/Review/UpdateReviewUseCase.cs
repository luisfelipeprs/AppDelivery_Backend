using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Review;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Review;
public class UpdateReviewUseCase : IUpdateReviewUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetReviewByIdUseCase _readOnlyRepository;
    private readonly IReviewUpdateOnlyRepository _repository;

    public UpdateReviewUseCase(IMapper mapper, IUnitOfWork unitOfWork, IReviewUpdateOnlyRepository repository, IGetReviewByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(long Id, RequestReviewJson request)
    {
        //Validate(request);

        var Review = await _repository.GetById(Id);
        if (Review is null) throw new NotFoundException("Review não encontrada.");

        _mapper.Map(request, Review);

        _repository.Update(Review);

        await _unitOfWork.Commit();
    }
}
