namespace AppDelivery.Communication.Responses
{
    public class ResponseOrderJson
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public string? PaymentMethod { get; set; }
        public Guid ConsumerId { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid DeliveryId { get; set; }
    }
}
