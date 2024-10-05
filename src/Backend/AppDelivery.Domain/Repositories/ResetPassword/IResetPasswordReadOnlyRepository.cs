namespace AppDelivery.Domain.Repositories.ResetPassword;
public interface IResetPasswordReadOnlyRepository
{
    public Task<Entities.PasswordResetToken?> GetToken(string token);
}
