public class Entregador
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Veiculo { get; set; } = string.Empty;
    public string PlacaVeiculo { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    // Relacionamento com pedidos
    //public List<Pedido>? Pedidos { get; set; }
}
