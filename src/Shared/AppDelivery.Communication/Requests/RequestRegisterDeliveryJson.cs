namespace AppDelivery.Communication.Requests;

public class RequestRegisterDeliveryJson
{
    public Guid DeliveryId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? Status { get; set; }
    public Guid OrderId { get; set; }
    public Guid DeliveryPersonId { get; set; }
}