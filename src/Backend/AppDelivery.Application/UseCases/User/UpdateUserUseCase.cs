using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.User;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.User;
public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetUserByIdUseCase _readOnlyRepository;
    private readonly IUserUpdateOnlyRepository _repository;

    public UpdateUserUseCase(IMapper mapper, IUnitOfWork unitOfWork, IUserUpdateOnlyRepository repository, IGetUserByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(Guid Id, RequestUserJson request)
    {
        //Validate(request);

        var User = await _repository.GetById(Id);
        if (User is null)
        {
            throw new NotFoundException("User not found.");
        }
        // pega os dados da request e insere dentro do objeto => User(ja criado)
        _mapper.Map(request, User);

        _repository.Update(User);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
