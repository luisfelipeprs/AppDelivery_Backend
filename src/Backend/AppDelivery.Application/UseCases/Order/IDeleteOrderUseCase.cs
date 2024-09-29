namespace AppDelivery.Application.UseCases.Order
{
    public interface IDeleteOrderUseCase
    {
        Task Execute(long id);
    }
}
