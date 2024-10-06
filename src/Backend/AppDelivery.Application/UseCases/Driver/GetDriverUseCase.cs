using AppDelivery.Communication.Responses;
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

        public async Task<ResponseDriversJson> GetDrivers()
        {
            var driver = await _readOnlyRepository.GetDrivers();
            return new ResponseDriversJson 
            { 
                Drivers = _mapper.Map<List<ResponseDriverDataJson>>(driver)
            };
        }

        public async Task<ResponseDriverByIdJson> Execute(long Id)
        {
            var driver = await _readOnlyRepository.GetDriverById(Id);

            return new ResponseDriverByIdJson
            {
                Driver = _mapper.Map<ResponseDriverDataJson>(driver)
            };
        }
    }
}
