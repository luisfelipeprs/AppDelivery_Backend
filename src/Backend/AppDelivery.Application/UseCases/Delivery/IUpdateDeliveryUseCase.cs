using AppDelivery.Communication.Requests;

namespace AppDelivery.Application.UseCases.Delivery
{
    public interface IUpdateDeliveryUseCase
    {
        Task Execute(Guid Id, RequestDeliveryJson request);
    }
}
