namespace AppDelivery.Communication.Responses
{
    public class ResponseRegisteredOrderJson
    {
        public long OrderId { get; set; }
        public string? PaymentMethod { get; set; }
    }
}
