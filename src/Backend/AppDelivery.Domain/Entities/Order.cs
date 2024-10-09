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

    public enum Load
    {
        Light = 0,
        Medium = 1,
        Heavy = 2,
    }

    public class Order
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public Load Load { get; set; }

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
        public Guid? DeliveryId { get; set; }
        public Guid? ConsumerId { get; set; }
        public Guid? CompanyId { get; set; }

        public Delivery? Delivery { get; set; }
        public Consumer? Consumer { get; set; }
        public Company? Company { get; set; }
    }
}