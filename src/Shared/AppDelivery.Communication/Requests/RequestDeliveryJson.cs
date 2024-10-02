﻿namespace AppDelivery.Communication.Requests;
public class RequestDeliveryJson
{
    public long DeliveryId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? Status { get; set; }
    public long OrderId { get; set; }
    public string Order { get; set; } = null!;
    public long DeliveryPersonId { get; set; }
}