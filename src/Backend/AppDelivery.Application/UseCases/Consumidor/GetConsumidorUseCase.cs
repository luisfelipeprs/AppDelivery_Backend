using AppDelivery.Domain.Repositories.Consumidor;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Consumidor
{
    public class GetConsumidorUseCase : IGetConsumidorUseCase, IGetConsumidorByIdUseCase
    {
        private readonly IConsumidorReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetConsumidorUseCase(
            IConsumidorReadOnlyRepository readOnlyRepository,
            IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;

        }

        public async Task<List<Domain.Entities.Consumidor>> GetConsumidores()
        {
            var consumidor = await _readOnlyRepository.GetConsumidores();
            return consumidor;
        }

        public async Task<Domain.Entities.Consumidor> Execute(long Id)
        {
            var consumidor = await _readOnlyRepository.GetConsumidorById(Id);

            return consumidor!;
        }
    }
}
