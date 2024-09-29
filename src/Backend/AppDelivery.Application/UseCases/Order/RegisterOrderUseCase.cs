using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Order;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Order;
public class RegisterOrderUseCase : IRegisterOrderUseCase
{
    private readonly IOrderWriteOnlyRepository _writeOnlyRepository;
    private readonly IOrderReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public RegisterOrderUseCase(
        IOrderWriteOnlyRepository writeOnlyRepository,
        IOrderReadOnlyRepository readOnlyRepository,
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

    public async Task<ResponseRegisteredOrderJson> Execute(RequestRegisterOrderJson request)
    {
        //await Validate(request);

        var order = _mapper.Map<Domain.Entities.Order>(request);

        await _writeOnlyRepository.Add(order);
        await _unitOfWork.Commit();

        return new ResponseRegisteredOrderJson
        {
            OrderId = request.OrderId,
        };
    }
}