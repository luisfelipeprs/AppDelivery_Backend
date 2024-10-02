using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Review;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Review;
public class RegisterReviewUseCase : IRegisterReviewUseCase
{
    private readonly IReviewWriteOnlyRepository _writeOnlyRepository;
    private readonly IReviewReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public RegisterReviewUseCase(
        IReviewWriteOnlyRepository writeOnlyRepository,
        IReviewReadOnlyRepository readOnlyRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        PasswordEncripter passwordEncripter)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;

    }

    public async Task<ResponseReviewJson> Execute(RequestReviewJson request)
    {
        //await Validate(request);

        var review = _mapper.Map<Domain.Entities.Review>(request);

        await _writeOnlyRepository.Add(review);
        await _unitOfWork.Commit();

        return new ResponseReviewJson
        {
            Id = request.EntityId,
        };
    }
}