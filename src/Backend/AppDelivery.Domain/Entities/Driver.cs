namespace AppDelivery.Domain.Entities
{
    public enum TypeDriver
    {
        Car = 0,
        Motorcycle = 1,
    }
    public class Driver : UserBase
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Cnh { get; set; } = string.Empty;
        public string Vehicle { get; set; } = string.Empty;
        public string DocumentationVehicle { get; set; } = string.Empty;

        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
        public TypeDriver TypeDriver { get; set; }

        public ICollection<Delivery>? Deliveries { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
