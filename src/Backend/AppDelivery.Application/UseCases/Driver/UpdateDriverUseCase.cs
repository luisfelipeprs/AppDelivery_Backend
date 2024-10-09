using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Driver;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Driver;
public class UpdateDriverUseCase : IUpdateDriverUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetDriverByIdUseCase _readOnlyRepository;
    private readonly IDriverUpdateOnlyRepository _repository;

    public UpdateDriverUseCase(IMapper mapper, IUnitOfWork unitOfWork, IDriverUpdateOnlyRepository repository, IGetDriverByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(Guid Id, RequestDriverJson request)
    {
        //Validate(request);

        var Driver = await _repository.GetById(Id);
        if (Driver is null) throw new NotFoundException("Entregador não encontrado.");

        // pega os dados da request e insere dentro do objeto => Driver(ja criado)
        _mapper.Map(request, Driver);

        _repository.Update(Driver);

        await _unitOfWork.Commit();
    }

    //private void Validate(RequestRegisterDriverJson request)
    //{
    //    var validator = new RegisterDriverValidator();

    //    var result = validator.Validate(request);

    //    if (result.IsValid == false)
    //    {
    //        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

    //        throw new ErrorOnValidationException(errorMessages);
    //    }
    //}
}
