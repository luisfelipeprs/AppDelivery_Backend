namespace AppDelivery.Application.UseCases.Order
{
    public interface IGetOrderUseCase
    {
        public Task<List<Domain.Entities.Order>> GetOrders();
        public Task<List<Domain.Entities.Order>> GetOrdersAvailable();
    }
}
