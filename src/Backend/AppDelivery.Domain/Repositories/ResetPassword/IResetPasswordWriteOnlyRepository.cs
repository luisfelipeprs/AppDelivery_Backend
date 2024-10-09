namespace AppDelivery.Domain.Repositories.ResetPassword;
public interface IResetPasswordWriteOnlyRepository
{
    public Task AddToken(Entities.PasswordResetToken passwordResetToken);
    Task<bool> Delete(Guid id);
}