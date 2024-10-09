namespace AppDelivery.Application.UseCases.Consumer;
public interface IDeleteConsumerUseCase
{
    Task Execute(Guid id);
}