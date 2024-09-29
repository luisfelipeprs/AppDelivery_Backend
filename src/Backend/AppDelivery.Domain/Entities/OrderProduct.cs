namespace AppDelivery.Domain.Entities
{
    public class OrderProduct
    {
        public long OrderId { get; set; }
        public Order? Order { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}
