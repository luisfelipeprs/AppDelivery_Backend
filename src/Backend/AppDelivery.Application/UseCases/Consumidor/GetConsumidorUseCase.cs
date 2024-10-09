using AppDelivery.Communication.Responses;
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

        public async Task<ResponseConsumerJson> GetConsumers()
        {
            var consumer = await _readOnlyRepository.GetConsumers();
            return new ResponseConsumerJson
            {
                Consumers = _mapper.Map<List<ResponseConsumerDataJson>>(consumer)
            };
        }

        public async Task<ResponseConsumerByIdJson> Execute(Guid Id)
        {
            var consumer = await _readOnlyRepository.GetConsumerById(Id);

            return new ResponseConsumerByIdJson
            {
                Consumer = _mapper.Map<ResponseConsumerDataJson>(consumer)
            };
        }
    }
}
