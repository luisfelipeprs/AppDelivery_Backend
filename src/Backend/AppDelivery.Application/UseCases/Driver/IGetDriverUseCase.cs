using AppDelivery.Communication.Responses;

namespace AppDelivery.Application.UseCases.Driver
{
    public interface IGetDriverUseCase
    {
        public Task<ResponseDriversJson> GetDrivers();
    }
}
