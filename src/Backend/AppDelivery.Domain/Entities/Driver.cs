using System;

namespace AppDelivery.Domain.Entities
{
    public enum TypeDriver
    {
        Undefined,
        Internal,
        External
    }
    public class Driver
    {
        public long Id { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Cnh { get; set; } = string.Empty;
        public string Vehicle { get; set; } = string.Empty;
        public string DocumentationVehicle { get; set; } = string.Empty;

        public int? CompanyId { get; set; }
        public TypeDriver TypeDriver { get; set; }

        //public ICollection<Delivery> Deliveries { get; set; }
    }
}
