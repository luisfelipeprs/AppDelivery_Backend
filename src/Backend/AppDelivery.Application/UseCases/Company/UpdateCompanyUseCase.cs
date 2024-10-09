using AppDelivery.Communication.Requests;
using AppDelivery.Domain.Repositories;
using AppDelivery.Domain.Repositories.Company;
using AppDelivery.Exception.ExceptionBase;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Company;
public class UpdateCompanyUseCase : IUpdateCompanyUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetCompanyByIdUseCase _readOnlyRepository;
    private readonly ICompanyUpdateOnlyRepository _repository;

    public UpdateCompanyUseCase(IMapper mapper, IUnitOfWork unitOfWork, ICompanyUpdateOnlyRepository repository, IGetCompanyByIdUseCase readOnlyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task Execute(Guid Id, RequestCompanyJson request)
    {
        //Validate(request);

        var Company = await _repository.GetById(Id);
        if (Company is null) throw new NotFoundException("Empresa não encontrada.");

        // pega os dados da request e insere dentro do objeto => Company(ja criado)
        _mapper.Map(request, Company);

        _repository.Update(Company);

        await _unitOfWork.Commit();
    }

    //private void Validate(RequestRegisterCompanyJson request)
    //{
    //    var validator = new RegisterCompanyValidator();

    //    var result = validator.Validate(request);

    //    if (result.IsValid == false)
    //    {
    //        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

    //        throw new ErrorOnValidationException(errorMessages);
    //    }
    //}
}
