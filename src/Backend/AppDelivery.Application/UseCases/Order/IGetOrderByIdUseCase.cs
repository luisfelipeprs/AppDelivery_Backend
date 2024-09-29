namespace AppDelivery.Application.UseCases.Order
{
    public interface IGetOrderByIdUseCase
    {
        Task<Domain.Entities.Order> Execute(long id);
    }
}
