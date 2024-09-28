using AppDelivery.Communication.Requests;

public interface IUpdateConsumidorUseCase
{
    Task Execute(long Id, RequestConsumidorJson request);

}
