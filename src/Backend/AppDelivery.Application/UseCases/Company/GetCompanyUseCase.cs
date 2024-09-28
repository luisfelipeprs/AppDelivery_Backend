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

        public async Task<List<Domain.Entities.Company>> GetCompanies()
        {
            var company = await _readOnlyRepository.GetCompanies();
            return company;
        }

        public async Task<Domain.Entities.Company> Execute(long Id)
        {
            var company = await _readOnlyRepository.GetCompanyById(Id);

            return company!;
        }
    }
}
