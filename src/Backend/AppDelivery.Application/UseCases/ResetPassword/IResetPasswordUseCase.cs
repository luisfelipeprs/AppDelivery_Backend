using AppDelivery.Communication.Requests;

namespace AppDelivery.Application.UseCases.ResetPassword;
public interface IResetPasswordUseCase
{
    public Task<string?> ResetPassword(RequestResetPasswordJson request);
    public Task ConfirmReset(RequestConfirmResetJson request);
}