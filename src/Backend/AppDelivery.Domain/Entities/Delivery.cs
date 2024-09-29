namespace AppDelivery.Domain.Entities
{
    public class Delivery
    {
        public long DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; } = string.Empty;

        // Relacionamento com o entregador
        public long DeliveryPersonId { get; set; }
        public Driver? Driver { get; set; }

        // Relacionamento com o pedido
        public long OrderId { get; set; }
        public List<Order>? Orders { get; set; }
    }

}
