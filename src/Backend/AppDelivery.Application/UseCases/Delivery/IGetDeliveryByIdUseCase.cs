namespace AppDelivery.Application.UseCases.Delivery
{
    public interface IGetDeliveryByIdUseCase
    {
        Task<Domain.Entities.Delivery> Execute(long id);
    }
}
