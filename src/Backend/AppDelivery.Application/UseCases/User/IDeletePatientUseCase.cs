namespace AppDelivery.Application.UseCases.User;
public interface IDeleteUserUseCase
{
    Task Execute(long id);
}