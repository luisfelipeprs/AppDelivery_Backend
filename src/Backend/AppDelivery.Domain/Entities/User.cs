namespace AppDelivery.Domain.Entities;

public abstract class User : EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone {  get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
