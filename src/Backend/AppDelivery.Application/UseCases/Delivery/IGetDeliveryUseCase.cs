namespace AppDelivery.Application.UseCases.Delivery
{
    public interface IGetDeliveryUseCase
    {
        public Task<List<Domain.Entities.Delivery>> GetDeliveries();
        public Task<List<Domain.Entities.Delivery>> GetDeliveriesRecords();
    }
}
