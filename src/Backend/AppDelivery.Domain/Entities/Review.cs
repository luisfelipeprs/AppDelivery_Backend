namespace AppDelivery.Domain.Entities;
public enum EntityType
{
    Company = 0,
    Driver = 1
}

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public EntityType EntityType { get; set; } // Indica se é avaliação de empresa ou entregador
    public Guid EntityId { get; set; } // ID da empresa ou entregador
    public Guid ConsumerId { get; set; } // ID do consumidor que fez a avaliação
    public int Rating { get; set; } // Nota dada pelo consumidor
    public string Comment { get; set; } = string.Empty; // Comentário da avaliação
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow; // Data da avaliação

    // Navegação
    public Company? Company { get; set; } = null;
    public Consumer? Consumer { get; set; } = null;
    public Driver? Driver { get; set; } = null;
}
