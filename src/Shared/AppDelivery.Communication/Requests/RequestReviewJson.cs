namespace AppDelivery.Communication.Requests
{
    public class RequestReviewJson
    {
        public long Id { get; set; } // ID da avaliação (pode ser opcional dependendo do uso)
        public long ConsumerId { get; set; } // ID do consumidor que fez a avaliação
        public string EntityType { get; set; } = string.Empty; // Tipo da entidade avaliada ("Company", "Driver")
        public long EntityId { get; set; } // ID da empresa ou do entregador avaliado
        public int Rating { get; set; } // Nota dada pelo consumidor
        public string Comment { get; set; } = string.Empty; // Comentário da avaliação
    }
}
