using AppDelivery.Communication.Requests;

namespace AppDelivery.Application.UseCases.Order
{
    public interface IUpdateOrderUseCase
    {
        Task Execute(long Id, RequestOrderJson request);
    }
}
