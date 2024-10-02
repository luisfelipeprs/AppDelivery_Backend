using AppDelivery.Application.Services.Cryptography;
using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Delivery;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Delivery;
public class RegisterDeliveryUseCase : IRegisterDeliveryUseCase
{
    private readonly IDeliveryWriteOnlyRepository _writeOnlyRepository;
    private readonly IDeliveryReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;

    public RegisterDeliveryUseCase(
        IDeliveryWriteOnlyRepository writeOnlyRepository,
        IDeliveryReadOnlyRepository readOnlyRepository,
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

    public async Task<ResponseRegisteredDeliveryJson> Execute(RequestRegisterDeliveryJson request)
    {
        //await Validate(request);

        var delivery = _mapper.Map<Domain.Entities.Delivery>(request);

        await _writeOnlyRepository.Add(delivery);
        await _unitOfWork.Commit();

        return new ResponseRegisteredDeliveryJson
        {
            DeliveryId = request.DeliveryId,
        };
    }
}