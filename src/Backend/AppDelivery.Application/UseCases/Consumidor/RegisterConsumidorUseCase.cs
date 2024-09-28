using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Application.UseCases.Consumidor;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Consumidor;
using AppDelivery.Domain.Repositories.User;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Consumidor;
public class RegisterConsumidorUseCase : IRegisterConsumidorUseCase
{
    private readonly IConsumidorWriteOnlyRepository _writeOnlyRepository;
    private readonly IConsumidorReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public RegisterConsumidorUseCase(
        IConsumidorWriteOnlyRepository writeOnlyRepository, 
        IConsumidorReadOnlyRepository readOnlyRepository,
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

    public async Task<ResponseRegisteredConsumidorJson> Execute(RequestRegisterConsumidorJson request)
    {
        //await Validate(request);

        var consumidor = _mapper.Map<Domain.Entities.Consumidor>(request);

        consumidor.Password = _passwordEncripter.Encrypt(request.Password); 

        await _writeOnlyRepository.Add(consumidor);
        await _unitOfWork.Commit(); 

        return new ResponseRegisteredConsumidorJson 
        { 
            Name = request.Nome,
        };
    }

    private async Task Validate(RequestRegisterConsumidorJson request)
    {
        var validator = new RegisterConsumidorValidator();

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
