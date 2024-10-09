using AppDelivery.Communication.Requests;

public interface IUpdateConsumerUseCase
{
    Task Execute(Guid Id, RequestConsumerJson request);

}
