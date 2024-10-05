using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Company;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Company;
public class LoginCompanyUseCase : ILoginCompanyUseCase
{
    private readonly ICompanyWriteOnlyRepository _writeOnlyRepository;
    private readonly ICompanyReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public LoginCompanyUseCase(
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

    public async Task<(ResponseLoginCompanyJson?, string)> Login(RequestLoginCompanyJson request)
    {
        //await Validate(request);

        var companyRequest = _mapper.Map<Domain.Entities.Company>(request);

        companyRequest.Password = _passwordEncripter.Encrypt(request.Password);

        var company = await _readOnlyRepository.GetCompanyByEmail(companyRequest.Email);

        if (company == null) 
        {
            return (null, "Email ou senha inválidos");
        }
        if (!company.Active) 
        {
            return (null, "Conta inativa");
        }
        if(company.Password != companyRequest.Password)
        {
            return (null, "Email ou senha inválidos");
        }

        return (new ResponseLoginCompanyJson
        {
            Id = company.Id
        }, string.Empty);
    }
}