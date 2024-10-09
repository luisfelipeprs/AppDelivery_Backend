using AppDelivery.Communication.Requests;

public interface IUpdateUserUseCase
{
    Task Execute(Guid Id, RequestUserJson request);

}
