namespace AppDelivery.Application.UseCases.Delivery
{
    public interface IDeleteDeliveryUseCase
    {
        Task Execute(long id);
    }
}
