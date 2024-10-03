namespace AppDelivery.Communication.Responses
{
    public class ResponseOrderJson
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public string? PaymentMethod { get; set; }
        public long ConsumerId { get; set; }
        public long CompanyId { get; set; }
        public long DeliveryId { get; set; }
    }
}
