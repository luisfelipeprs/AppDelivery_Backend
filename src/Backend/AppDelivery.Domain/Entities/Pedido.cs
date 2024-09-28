using AppDelivery.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public decimal ValorTotal { get; set; }

    // Chave estrangeira para o Consumidor
    public int ConsumidorId { get; set; }
    public Consumidor? Consumidor { get; set; }

    // Chave estrangeira para a Empresa
    public int EmpresaId { get; set; }
    public Empresa? Empresa { get; set; }

    // Chave estrangeira para o Entregador
    public int EntregadorId { get; set; }
    public Entregador? Entregador { get; set; }
}
