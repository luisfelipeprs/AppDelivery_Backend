using AppDelivery.Domain.Repositories.Consumer;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Consumer
{
    public class GetConsumerUseCase : IGetConsumerUseCase, IGetConsumerByIdUseCase
    {
        private readonly IConsumerReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetConsumerUseCase(
            IConsumerReadOnlyRepository readOnlyRepository,
            IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;

        }

        public async Task<List<Domain.Entities.Consumer>> GetConsumers()
        {
            var consumer = await _readOnlyRepository.GetConsumers();
            return consumer;
        }

        public async Task<Domain.Entities.Consumer> Execute(long Id)
        {
            var consumer = await _readOnlyRepository.GetConsumerById(Id);

            return consumer!;
        }
    }
}
