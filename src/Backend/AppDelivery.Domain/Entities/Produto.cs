public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    // Chave estrangeira para a Empresa
    public int EmpresaId { get; set; }
    public Empresa? Empresa { get; set; }
}
