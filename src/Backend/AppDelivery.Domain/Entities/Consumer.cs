namespace AppDelivery.Domain.Entities;
public class Consumer
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
    
    public List<Order>? Orders { get; set; }
    public List<Review>? Reviews { get; set; }


    // Relacionamento com pedidos
    //public List<Pedido>? Pedidos { get; set; }


}
