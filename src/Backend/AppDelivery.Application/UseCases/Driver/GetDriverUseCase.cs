using AppDelivery.Domain.Repositories.Driver;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Driver
{
    public class GetDriverUseCase : IGetDriverUseCase, IGetDriverByIdUseCase
    {
        private readonly IDriverReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetDriverUseCase(
            IDriverReadOnlyRepository readOnlyRepository,
            IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;

        }

        public async Task<List<Domain.Entities.Driver>> GetDrivers()
        {
            var driver = await _readOnlyRepository.GetDrivers();
            return driver;
        }

        public async Task<Domain.Entities.Driver> Execute(long Id)
        {
            var driver = await _readOnlyRepository.GetDriverById(Id);

            return driver!;
        }
    }
}
