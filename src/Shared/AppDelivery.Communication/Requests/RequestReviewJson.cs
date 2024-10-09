namespace AppDelivery.Communication.Requests
{
    public class RequestReviewJson
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // ID da avaliação (pode ser opcional dependendo do uso)
        public Guid ConsumerId { get; set; } // ID do consumidor que fez a avaliação
        public string EntityType { get; set; } = string.Empty; // Tipo da entidade avaliada ("Company", "Driver")
        public Guid EntityId { get; set; } // ID da empresa ou do entregador avaliado
        public int Rating { get; set; } // Nota dada pelo consumidor
        public string Comment { get; set; } = string.Empty; // Comentário da avaliação
    }
}
