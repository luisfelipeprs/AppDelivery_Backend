using AppDelivery.Communication.Responses;
using AppDelivery.Domain.Repositories.Company;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Company
{
    public class GetCompanyUseCase : IGetCompanyUseCase, IGetCompanyByIdUseCase
    {
        private readonly ICompanyReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetCompanyUseCase(
            ICompanyReadOnlyRepository readOnlyRepository,
            IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;

        }

        public async Task<ResponseCompaniesJson> GetCompanies()
        {
            var companies = await _readOnlyRepository.GetCompanies();
            return new ResponseCompaniesJson
            {
                Companies = _mapper.Map<List<ResponseShortCompanyJson>>(companies)
            };
        }

        public async Task<ResponseCompanyJson> Execute(Guid Id)
        {
            var company = await _readOnlyRepository.GetCompanyById(Id);

            return new ResponseCompanyJson
            {
                Company = _mapper.Map<ResponseCompanyDataJson>(company)
            };
        }
    }
}
