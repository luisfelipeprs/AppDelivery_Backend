namespace AppDelivery.Application.UseCases.Driver
{
    public interface IGetDriverByIdUseCase
    {
        Task<Domain.Entities.Driver> Execute(long id);
    }
}
