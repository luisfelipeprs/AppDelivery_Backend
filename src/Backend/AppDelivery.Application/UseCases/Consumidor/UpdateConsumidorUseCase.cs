using AppDelivery.Communication.Requests;
using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Consumer;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Consumer;
public class UpdateConsumerUseCase : IUpdateConsumerUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetConsumerByIdUseCase _readOnlyRepository;
    private readonly IConsumerUpdateOnlyRepository _repository;

    public UpdateConsumerUseCase(IMapper mapper, IUnitOfWork unitOfWork, IConsumerUpdateOnlyRepository repository, IGetConsumerByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(long Id, RequestConsumerJson request)
    {
        //Validate(request);

        var Consumer = await _repository.GetById(Id);
        if (Consumer is null) throw new NotFoundException("Consumer não encontrado.");

        // pega os dados da request e insere dentro do objeto => Consumer(ja criado)
        _mapper.Map(request, Consumer);

        _repository.Update(Consumer);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestRegisterConsumerJson request)
    {
        var validator = new RegisterConsumerValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
