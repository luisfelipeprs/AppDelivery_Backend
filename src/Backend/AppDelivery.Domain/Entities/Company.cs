namespace AppDelivery.Domain.Entities
{
    public class Company
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string NumberLocation { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }

    }
}
