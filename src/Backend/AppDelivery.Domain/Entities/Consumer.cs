namespace AppDelivery.Domain.Entities;
public class Consumer : UserBase
{
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
    
    public List<Order>? Orders { get; set; }
    public List<Review>? Reviews { get; set; }


    // Relacionamento com pedidos
    //public List<Pedido>? Pedidos { get; set; }


}
