namespace AppDelivery.Communication.Requests
{
    public class RequestRegisterOrderJson
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
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

        // Alterar para TypeDriver
        public string? DeliveryType { get; set; } = string.Empty;

        // Informações de entrega
        public long? DeliveryId { get; set; }
        public long? ConsumerId { get; set; }
        public long? CompanyId { get; set; }
    }
}
