namespace AppDelivery.Domain.Entities
{
    public abstract class UserBase
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
