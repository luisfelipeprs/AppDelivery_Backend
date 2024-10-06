using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Driver
{
    public interface IGetDriverByIdUseCase
    {
        Task<ResponseDriverByIdJson> Execute(long id);
    }
}
