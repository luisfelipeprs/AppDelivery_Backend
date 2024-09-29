namespace AppDelivery.Communication.Requests;
public class RequestOrderJson
{
    public long OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public long ConsumerId { get; set; }
    public long CompanyId { get; set; }
    public long DeliveryId { get; set; }

}
