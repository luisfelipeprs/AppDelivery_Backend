namespace AppDelivery.Domain.Entities;

public enum TypeEntity
{
    Consumer = 0,
    Driver = 1,
    Company = 2
}
public class PasswordResetToken
{
    public long Id { get; set; }
    public TypeEntity TypeEntity { get; set; }
    public long EntityId { get; set; }
    public string ResetToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool Used { get; set; } = false;
}