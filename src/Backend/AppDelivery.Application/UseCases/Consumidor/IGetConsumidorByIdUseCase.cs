namespace AppDelivery.Application.UseCases.Consumer;
public interface IGetConsumerByIdUseCase
{
    Task<Domain.Entities.Consumer> Execute(long id);
}
