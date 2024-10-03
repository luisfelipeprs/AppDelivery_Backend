using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Consumer;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Consumer;
public class LoginConsumerUseCase : ILoginConsumerUseCase
{
    private readonly IConsumerWriteOnlyRepository _writeOnlyRepository;
    private readonly IConsumerReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public LoginConsumerUseCase(
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

    public async Task<(ResponseLoginConsumerJson?, string)> Login(RequestLoginConsumerJson request)
    {
        //await Validate(request);

        var consumerRequest = _mapper.Map<Domain.Entities.Consumer>(request);

        consumerRequest.Password = _passwordEncripter.Encrypt(request.Password);

        var consumer = await _readOnlyRepository.GetByEmail(consumerRequest.Email);

        if (consumer == null) 
        {
            return (null, "Email ou senha inválidos");
        }
        if (!consumer.Active) 
        {
            return (null, "Conta inativa");
        }
        if(consumer.Password != consumerRequest.Password)
        {
            return (null, "Email ou senha inválidos");
        }

        return (new ResponseLoginConsumerJson
        {
            Id = consumer.Id
        }, string.Empty);
    }
}