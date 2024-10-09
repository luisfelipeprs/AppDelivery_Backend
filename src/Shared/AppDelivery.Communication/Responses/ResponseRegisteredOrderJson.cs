namespace AppDelivery.Communication.Responses
{
    public class ResponseRegisteredOrderJson
    {
        public Guid OrderId { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
