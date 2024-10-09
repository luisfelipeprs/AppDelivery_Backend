namespace AppDelivery.Communication.Requests
{
    public class RequestRegisterOrderJson
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string? PaymentMethod { get; set; }


        public double SenderLatitude { get; set; }
        public double SenderLongitude { get; set; }

        public double? StopLatitude { get; set; }
        public double? StopLongitude { get; set; }

        public double RecipientLatitude { get; set; }
        public double RecipientLongitude { get; set; }

        public string? DeliveryType { get; set; } = string.Empty;

        public string? Load { get; set; } = string.Empty;

        public Guid? DeliveryId { get; set; } = null;
        public Guid? ConsumerId { get; set; }
        public Guid? CompanyId { get; set; }
    }
}
