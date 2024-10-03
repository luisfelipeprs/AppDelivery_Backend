namespace AppDelivery.Domain.Entities
{
    public enum OrderStatus
    {
        Available = 0, // disponivel pra entrega     
        InProgress = 1, // aceito pra entrega
        Canceled = 2, // cancelado
        Finished = 3 // pedido finalizado/concluído
    }
    public enum PaymentMethod
    {
        Pix = 0,
        Money = 1,
        Debit = 2,
        Credit = 3
    }

    public class Order
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;

        // remetente
        public double SenderLatitude { get; set; }
        public double SenderLongitude { get; set; }

        // parada (opcional)
        public double? StopLatitude { get; set; } // Nullable para ser opcional
        public double? StopLongitude { get; set; } // Nullable para ser opcional

        // destinatário
        public double RecipientLatitude { get; set; }
        public double RecipientLongitude { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public TypeDriver DeliveryType { get; set; }

        // Informações de entrega
        public long? DeliveryId { get; set; }
        public long? ConsumerId { get; set; }
        public long? CompanyId { get; set; }        
        
        public Delivery? Delivery { get; set; }
        public Consumer? Consumer { get; set; }
        public Company? Company { get; set; }
    }

}
