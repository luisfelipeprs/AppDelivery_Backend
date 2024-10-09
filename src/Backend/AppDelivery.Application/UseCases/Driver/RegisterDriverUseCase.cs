using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Driver;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Driver;
public class RegisterDriverUseCase : IRegisterDriverUseCase
{
    private readonly IDriverWriteOnlyRepository _writeOnlyRepository;
    private readonly IDriverReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public RegisterDriverUseCase(
        IDriverWriteOnlyRepository writeOnlyRepository,
        IDriverReadOnlyRepository readOnlyRepository,
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

    public async Task<ResponseRegisteredDriverJson> Execute(RequestRegisterDriverJson request)
    {
        //await Validate(request);

        var driver = _mapper.Map<Domain.Entities.Driver>(request);

        driver.Password = _passwordEncripter.Encrypt(request.Password);

        await _writeOnlyRepository.Add(driver);
        await _unitOfWork.Commit();

        return new ResponseRegisteredDriverJson
        {
            Id = driver.Id,
            Name = request.Name,
            Email = request.Email,
        };
    }
}