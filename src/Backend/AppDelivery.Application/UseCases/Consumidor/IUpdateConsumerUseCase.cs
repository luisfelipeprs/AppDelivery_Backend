using AppDelivery.Communication.Requests;

public interface IUpdateConsumerUseCase
{
    Task Execute(long Id, RequestConsumerJson request);

}
