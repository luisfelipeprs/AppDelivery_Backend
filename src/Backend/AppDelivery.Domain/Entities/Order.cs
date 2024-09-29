namespace AppDelivery.Domain.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public long ConsumerId { get; set; }
        public long CompanyId { get; set; }
        public long DeliveryId { get; set; }
        public Consumer? Consumer { get; set; }
        public Company? Company { get; set; }
        public Delivery? Delivery { get; set; }
        public List<OrderProduct>? OrderProducts { get; set; }
    }

}
