namespace AppDelivery.Domain.Entities;
public class Consumidor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

    // Relacionamento com pedidos
    //public List<Pedido>? Pedidos { get; set; }


}
