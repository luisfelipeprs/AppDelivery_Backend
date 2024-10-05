namespace AppDelivery.Domain.Entities
{
    public class Company : UserBase
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Cnpj { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string NumberLocation { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public double Latitude {  get; set; }
        public double Longitude {  get; set; }
        public string Phone { get; set; } = string.Empty;
        public string TypeCompany { get; set; } = string.Empty; // cafeteria, padaria, etc...
        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

    }
}
