namespace AppDelivery.Application.UseCases.Consumer;
public interface IDeleteConsumerUseCase
{
    Task Execute(long id);
}