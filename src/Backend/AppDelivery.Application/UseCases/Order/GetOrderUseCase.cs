using AppDelivery.Domain.Repositories.Order;
using AutoMapper;

namespace AppDelivery.Application.UseCases.Order
{
    public class GetOrderUseCase : IGetOrderUseCase, IGetOrderByIdUseCase
    {
        private readonly IOrderReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetOrderUseCase(
            IOrderReadOnlyRepository readOnlyRepository,
            IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;

        }

        public async Task<List<Domain.Entities.Order>> GetOrders()
        {
            var order = await _readOnlyRepository.GetOrders();
            return order;
        }

        public async Task<Domain.Entities.Order> Execute(Guid Id)
        {
            var order = await _readOnlyRepository.GetOrderById(Id);

            return order!;
        }

        public async Task<List<Domain.Entities.Order>> GetOrdersAvailable()
        {
            var order = await _readOnlyRepository.GetOrdersAvailable();
            return order;
        }
    }
}
