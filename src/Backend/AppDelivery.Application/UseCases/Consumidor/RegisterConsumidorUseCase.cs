using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Application.UseCases.Consumer;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Consumer;
using AppDelivery.Domain.Repositories.User;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Consumer;
public class RegisterConsumerUseCase : IRegisterConsumerUseCase
{
    private readonly IConsumerWriteOnlyRepository _writeOnlyRepository;
    private readonly IConsumerReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public RegisterConsumerUseCase(
        IConsumerWriteOnlyRepository writeOnlyRepository, 
        IConsumerReadOnlyRepository readOnlyRepository,
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

    public async Task<ResponseRegisteredConsumerJson> Execute(RequestRegisterConsumerJson request)
    {
        //await Validate(request);

        var consumer = _mapper.Map<Domain.Entities.Consumer>(request);

        consumer.Password = _passwordEncripter.Encrypt(request.Password); 

        await _writeOnlyRepository.Add(consumer);
        await _unitOfWork.Commit(); 

        return new ResponseRegisteredConsumerJson 
        { 
            Name = request.Nome,
        };
    }

    private async Task Validate(RequestRegisterConsumerJson request)
    {
        var validator = new RegisterConsumerValidator();

        var result = validator.Validate(request);

        //var emailExister = await _readOnlyRepository.ExistActiveUserWithEmail(request.Email);
        //if (emailExister)
        //{
        //    result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_EXISTS));
        //}

        //if (result.IsValid == false)
        //{
        //    var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

        //    throw new ErrorOnValidationException(errorMessages);
        //}
        //if (string.IsNullOrEmpty(request.Name))
        //{
        //    throw new ArgumentException();
        //}
    }
}
