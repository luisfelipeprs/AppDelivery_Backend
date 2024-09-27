using AppDelivery.Communication.Requests;

public interface IUpdateUserUseCase
{
    Task Execute(long Id, RequestUserJson request);

}
