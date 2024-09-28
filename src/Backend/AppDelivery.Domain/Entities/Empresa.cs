public class Empresa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }

    // Relacionamento com produtos
    public List<Produto> Produtos { get; set; }

    // Relacionamento com pedidos
    public List<Pedido> Pedidos { get; set; }
}
