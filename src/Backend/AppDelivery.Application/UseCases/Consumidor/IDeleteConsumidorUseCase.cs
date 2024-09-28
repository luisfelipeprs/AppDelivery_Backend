namespace AppDelivery.Application.UseCases.Consumidor;
public interface IDeleteConsumidorUseCase
{
    Task Execute(long id);
}