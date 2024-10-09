using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Delivery;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Delivery;
public class UpdateDeliveryUseCase : IUpdateDeliveryUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetDeliveryByIdUseCase _readOnlyRepository;
    private readonly IDeliveryUpdateOnlyRepository _repository;

    public UpdateDeliveryUseCase(IMapper mapper, IUnitOfWork unitOfWork, IDeliveryUpdateOnlyRepository repository, IGetDeliveryByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(Guid Id, RequestDeliveryJson request)
    {
        //Validate(request);

        var Delivery = await _repository.GetById(Id);
        if (Delivery is null) throw new NotFoundException("Entrega não encontrada.");

        // pega os dados da request e insere dentro do objeto => Delivery(ja criado)
        _mapper.Map(request, Delivery);

        _repository.Update(Delivery);

        await _unitOfWork.Commit();
    }

    //private void Validate(RequestRegisterDeliveryJson request)
    //{
    //    var validator = new RegisterDeliveryValidator();

    //    var result = validator.Validate(request);

    //    if (result.IsValid == false)
    //    {
    //        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

    //        throw new ErrorOnValidationException(errorMessages);
    //    }
    //}
}
