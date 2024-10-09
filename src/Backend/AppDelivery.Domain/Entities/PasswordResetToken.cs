namespace AppDelivery.Domain.Entities;

public enum TypeEntity
{
    Consumer = 0,
    Driver = 1,
    Company = 2
}
public class PasswordResetToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public TypeEntity TypeEntity { get; set; }
    public Guid EntityId { get; set; } = Guid.NewGuid();
    public string ResetToken { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool Used { get; set; } = false;
}