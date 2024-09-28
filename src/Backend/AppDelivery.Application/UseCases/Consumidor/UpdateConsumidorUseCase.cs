using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Consumidor;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Consumidor;
public class UpdateConsumidorUseCase : IUpdateConsumidorUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetConsumidorByIdUseCase _readOnlyRepository;
    private readonly IConsumidorUpdateOnlyRepository _repository;

    public UpdateConsumidorUseCase(IMapper mapper, IUnitOfWork unitOfWork, IConsumidorUpdateOnlyRepository repository, IGetConsumidorByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(long Id, RequestConsumidorJson request)
    {
        //Validate(request);

        var Consumidor = await _repository.GetById(Id);
        if (Consumidor is null) throw new NotFoundException("Consumidor não encontrado.");

        // pega os dados da request e insere dentro do objeto => Consumidor(ja criado)
        _mapper.Map(request, Consumidor);

        _repository.Update(Consumidor);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestRegisterConsumidorJson request)
    {
        var validator = new RegisterConsumidorValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
