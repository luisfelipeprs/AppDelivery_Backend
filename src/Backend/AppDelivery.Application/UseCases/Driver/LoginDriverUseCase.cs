using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Driver;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Driver;
public class LoginDriverUseCase : ILoginDriverUseCase
{
    private readonly IDriverWriteOnlyRepository _writeOnlyRepository;
    private readonly IDriverReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public LoginDriverUseCase(
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

    public async Task<(ResponseLoginDriverJson?, string)> Login(RequestLoginDriverJson request)
    {
        //await Validate(request);

        var driverRequest = _mapper.Map<Domain.Entities.Driver>(request);

        driverRequest.Password = _passwordEncripter.Encrypt(request.Password);

        var driver = await _readOnlyRepository.GetDriverByEmail(driverRequest.Email);

        if (driver == null) 
        {
            return (null, "Email ou senha inválidos");
        }
        if (!driver.Active) 
        {
            return (null, "Conta inativa");
        }
        if(driver.Password != driverRequest.Password)
        {
            return (null, "Email ou senha inválidos");
        }

        return (new ResponseLoginDriverJson
        {
            Id = driver.Id
        }, string.Empty);
    }
}