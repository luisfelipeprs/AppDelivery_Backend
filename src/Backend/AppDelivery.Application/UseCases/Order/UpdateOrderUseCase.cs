using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Order;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Order;
public class UpdateOrderUseCase : IUpdateOrderUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetOrderByIdUseCase _readOnlyRepository;
    private readonly IOrderUpdateOnlyRepository _repository;

    public UpdateOrderUseCase(IMapper mapper, IUnitOfWork unitOfWork, IOrderUpdateOnlyRepository repository, IGetOrderByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(long Id, RequestOrderJson request)
    {
        //Validate(request);

        var Order = await _repository.GetById(Id);
        if (Order is null) throw new NotFoundException("Pedido não encontrado.");

        // pega os dados da request e insere dentro do objeto => Order(ja criado)
        _mapper.Map(request, Order);

        _repository.Update(Order);

        await _unitOfWork.Commit();
    }

    //private void Validate(RequestRegisterOrderJson request)
    //{
    //    var validator = new RegisterOrderValidator();

    //    var result = validator.Validate(request);

    //    if (result.IsValid == false)
    //    {
    //        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

    //        throw new ErrorOnValidationException(errorMessages);
    //    }
    //}
}
