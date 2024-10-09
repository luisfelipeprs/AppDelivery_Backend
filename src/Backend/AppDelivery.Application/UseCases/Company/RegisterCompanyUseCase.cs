using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Application.UseCases.Company;
using AppDelivery.Application.UseCases.Consumer;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Company;
using AppDelivery.Domain.Repositories.User;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Company;
public class RegisterCompanyUseCase : IRegisterCompanyUseCase
{
    private readonly ICompanyWriteOnlyRepository _writeOnlyRepository;
    private readonly ICompanyReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public RegisterCompanyUseCase(
        ICompanyWriteOnlyRepository writeOnlyRepository,
        ICompanyReadOnlyRepository readOnlyRepository,
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

    public async Task<ResponseRegisteredCompanyJson> Execute(RequestRegisterCompanyJson request)
    {
        //await Validate(request);

        var company = _mapper.Map<Domain.Entities.Company>(request);

        company.Password = _passwordEncripter.Encrypt(request.Password);

        await _writeOnlyRepository.Add(company);
        await _unitOfWork.Commit();

        return new ResponseRegisteredCompanyJson
        {
            Name = request.Name,
            Email = request.Email,
            Id = company.Id
        };
    }

    //private async Task Validate(RequestRegisterCompanyJson request)
    //{
    //    var validator = new RegisterCompanyValidator();

    //    var result = validator.Validate(request);
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
    //}
}
