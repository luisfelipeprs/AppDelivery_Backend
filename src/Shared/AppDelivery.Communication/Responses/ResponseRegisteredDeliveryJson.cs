namespace AppDelivery.Communication.Responses;
public class ResponseRegisteredDeliveryJson
    {

    public Guid DeliveryId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? Status { get; set; }
    public Guid OrderId { get; set; }
    public string Order { get; set; } = null!;
    public Guid DeliveryPersonId { get; set; }
}
