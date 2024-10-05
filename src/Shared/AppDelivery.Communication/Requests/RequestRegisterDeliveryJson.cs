namespace AppDelivery.Communication.Requests;

public class RequestRegisterDeliveryJson
{
    public long DeliveryId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? Status { get; set; }
    public long OrderId { get; set; }
    public long DeliveryPersonId { get; set; }
}