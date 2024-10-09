namespace AppDelivery.Domain.Entities
{
    public enum DeliveryStatus
    {
        NotStarted = 0,
        InTransit = 1,
        Delivered = 2,
        Failed = 3
    }
    public class Delivery
    {
        public Guid DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DeliveryStatus Status { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public Guid DeliveryPersonId { get; set; }
        public Driver? Driver { get; set; }
    }
}
