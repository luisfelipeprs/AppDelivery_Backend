using System;

namespace AppDelivery.Domain.Entities
{
    public enum TypeDriver
    {
        Undefined,
        Internal,
        External
    }
    public class Driver : User
    {
        public string Cnh { get; set; }
        public string Vehicle { get; set; }
        public string DocumentationVehicle { get; set; }

        public int? EmpresaId { get; set; }
        public TypeDriver TypeDriver { get; set; }
        public DateTime DataCadastro { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }
    }
}
