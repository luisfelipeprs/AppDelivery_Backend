using AppDelivery.Communication.Requests;

namespace AppDelivery.Application.UseCases.Delivery
{
    public interface IUpdateDeliveryUseCase
    {
        Task Execute(long Id, RequestDeliveryJson request);
    }
}
