using AppDelivery.Domain.Repositories.Delivery;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Delivery
{
    public class GetDeliveryUseCase : IGetDeliveryUseCase, IGetDeliveryByIdUseCase
    {
        private readonly IDeliveryReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetDeliveryUseCase(
            IDeliveryReadOnlyRepository readOnlyRepository,
            IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;

        }

        public async Task<List<Domain.Entities.Delivery>> GetDeliveries()
        {
            var delivery = await _readOnlyRepository.GetDeliveries();
            return delivery;
        }

        public async Task<Domain.Entities.Delivery> Execute(Guid Id)
        {
            var delivery = await _readOnlyRepository.GetDeliveryById(Id);

            return delivery!;
        }

        public async Task<List<Domain.Entities.Delivery>> GetDeliveriesRecords() => await _readOnlyRepository.GetDeliveriesRecords();
    }
}
