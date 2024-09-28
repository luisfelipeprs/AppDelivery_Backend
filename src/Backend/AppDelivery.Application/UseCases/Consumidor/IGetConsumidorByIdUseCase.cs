namespace AppDelivery.Application.UseCases.Consumidor;
public interface IGetConsumidorByIdUseCase
{
    Task<Domain.Entities.Consumidor> Execute(long id);
}
